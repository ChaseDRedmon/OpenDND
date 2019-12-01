using System;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenDND.Controllers;
using OpenDND.Data.Models;
using OpenDND.DiscordBot;
using OpenDND.Services.Core;

namespace OpenDND.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds application servers to the ServiceCollection 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOpenDNDServices(this IServiceCollection services)
        {
            //services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<AntiForgeryController>();
            
            /*services.AddSingleton(
                provider => new DiscordSocketClient(config: new DiscordSocketConfig
                {
                    AlwaysDownloadUsers = true,
                    LogLevel = LogSeverity.Debug,
                    MessageCacheSize = provider
                        .GetRequiredService<IOptions<OpenDNDConfig>>()
                        .Value
                        .MessageCacheSize //needed to log deletions
                }));

            //services.AddSingleton<IDiscordSocketClient>(provider => provider.GetRequiredService<DiscordSocketClient>().Abstract());
            services.AddSingleton<IDiscordClient>(provider => provider.GetRequiredService<DiscordSocketClient>());

            services.AddSingleton(
                provider => new DiscordRestClient(config: new DiscordRestConfig
                {
                    LogLevel = LogSeverity.Debug,
                }));
            
            services.AddSingleton<DiscordSerilogAdapter>();
            services.AddHostedService<OpenDndBot>();*/
            
            return services;
        }
    }
}