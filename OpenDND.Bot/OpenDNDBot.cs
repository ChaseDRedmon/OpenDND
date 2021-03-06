﻿using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenDND.Data;
using OpenDND.Data.Models;
using OpenDND.Services;
using OpenDND.Services.BehaviorConfiguration;

namespace OpenDND.DiscordBot
{
    public sealed class OpenDndBot : BackgroundService
    {
        private readonly DiscordSocketClient _discordClient;
        private readonly DiscordRestClient _restClient;
        private readonly CommandService _commands;
        private readonly IServiceProvider _provider;
        private readonly OpenDNDConfig _config;
        private readonly DiscordSerilogAdapter _serilogAdapter;
        private readonly IApplicationLifetime _applicationLifetime;
        private readonly IHostingEnvironment _env;
        private IServiceScope _scope;
        private readonly ConcurrentDictionary<ICommandContext, IServiceScope> _commandScopes = new ConcurrentDictionary<ICommandContext, IServiceScope>();
        private ILogger<OpenDndBot> Log { get; }
        
        public OpenDndBot(
            DiscordSocketClient discordClient,
            DiscordRestClient restClient,
            IOptions<OpenDNDConfig> openDndConfig,
            CommandService commandService,
            DiscordSerilogAdapter serilogAdapter,
            IApplicationLifetime applicationLifetime,
            IServiceProvider serviceProvider,
            ILogger<OpenDndBot> logger,
            IHostingEnvironment env)
        {
            _discordClient = discordClient ?? throw new ArgumentNullException(nameof(discordClient));
            _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
            _config = openDndConfig?.Value ?? throw new ArgumentNullException(nameof(openDndConfig));
            _commands = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _provider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _serilogAdapter = serilogAdapter ?? throw new ArgumentNullException(nameof(serilogAdapter));
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            Log = logger ?? throw new ArgumentNullException(nameof(logger));
            _env = env;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Log.LogInformation("Starting bot background service.");

            IServiceScope scope = null;
            try
            {
                // Create a new scope for the session.
                scope = _provider.CreateScope();

                Log.LogTrace("Registering listeners for Discord client events.");

                _discordClient.LatencyUpdated += OnLatencyUpdated;
                _discordClient.Disconnected += OnDisconnect;

                _discordClient.Log += _serilogAdapter.HandleLog;
                _restClient.Log += _serilogAdapter.HandleLog;
                _commands.Log += _serilogAdapter.HandleLog;

                // Register with the cancellation token so we can stop listening to client events if the service is
                // shutting down or being disposed.
                stoppingToken.Register(OnStopping);

                // Database migrations
                Log.LogInformation("Running database migrations.");
                scope.ServiceProvider.GetRequiredService<OpenDNDContext>()
                    .Database.Migrate();

                Log.LogInformation("Starting behaviors.");
                await scope.ServiceProvider.GetRequiredService<IBehaviourConfigurationService>()
                    .LoadBehaviourConfiguration();

                foreach (var behavior in scope.ServiceProvider.GetServices<IBehavior>())
                {
                    await behavior.StartAsync();
                    stoppingToken.Register(() => behavior.StopAsync().GetAwaiter().GetResult());
                }

                // The only thing that could go wrong at this point is the client failing to login and start. Promote
                // our local service scope to a field so that it's available to the HandleCommand method once events
                // start firing after we've connected.
                _scope = scope;

                Log.LogInformation("Loading command modules...");

                await _commands.AddModulesAsync(typeof(OpenDndBot).Assembly, _scope.ServiceProvider);

                Log.LogInformation("{Modules} modules loaded, containing {Commands} commands",
                    _commands.Modules.Count(), _commands.Modules.SelectMany(d=>d.Commands).Count());

                Log.LogInformation("Logging into Discord and starting the client.");

                await StartClient(stoppingToken);

                Log.LogInformation("Discord client started successfully.");

                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "An error occurred while attempting to start the background service.");

                try
                {
                    OnStopping();

                    Log.LogInformation("Logging out of Discord.");
                    await _discordClient.LogoutAsync();
                }
                finally
                {
                    scope?.Dispose();
                    _scope = null;
                }

                throw;
            }

            void OnStopping()
            {
                Log.LogInformation("Stopping background service.");

                _discordClient.Disconnected -= OnDisconnect;
                _discordClient.LatencyUpdated -= OnLatencyUpdated;

                _discordClient.Log -= _serilogAdapter.HandleLog;
                _commands.Log -= _serilogAdapter.HandleLog;
                _restClient.Log -= _serilogAdapter.HandleLog;

                foreach (var context in _commandScopes.Keys)
                {
                    _commandScopes.TryRemove(context, out var commandScope);
                    commandScope?.Dispose();
                }
            }
        }

        private Task OnLatencyUpdated(int arg1, int arg2)
        {
            if (_env.IsProduction())
            {
                return File.WriteAllTextAsync("healthcheck.txt", DateTimeOffset.UtcNow.ToString("o"));
            }

            return Task.CompletedTask;
        }

        private Task OnDisconnect(Exception ex)
        {
            Log.LogInformation(ex, "The bot disconnected unexpectedly. Stopping the application.");
            _applicationLifetime.StopApplication();
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            try
            {
                // If the service is currently running, this will cancel the cancellation token that was passed into
                // our ExecuteAsync method, unregistering our event handlers for us.
                base.Dispose();
            }
            finally
            {
                _scope?.Dispose();
                _discordClient.Dispose();
                _restClient.Dispose();
            }
        }

        private async Task StartClient(CancellationToken cancellationToken)
        {
            try
            {
                _discordClient.Ready += OnClientReady;

                cancellationToken.ThrowIfCancellationRequested();

                await _discordClient.LoginAsync(TokenType.Bot, _config.DiscordToken);
                await _discordClient.StartAsync();

                await _restClient.LoginAsync(TokenType.Bot, _config.DiscordToken);
            }
            catch (Exception)
            {
                _discordClient.Ready -= OnClientReady;

                throw;
            }

            async Task OnClientReady()
            {
                Log.LogTrace("Discord client is ready. Setting game status.");
                _discordClient.Ready -= OnClientReady;
                await _discordClient.SetGameAsync(_config.WebsiteBaseUrl);
            }
        }
    }
}
