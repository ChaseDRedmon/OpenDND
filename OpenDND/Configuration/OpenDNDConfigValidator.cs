using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using OpenDND.Data.Models;
using Serilog;

namespace OpenDND.Configuration
{
    public class OpenDNDConfigValidator : IStartupFilter
    {
        private readonly OpenDNDConfig _config;

        public OpenDNDConfigValidator(IOptions<OpenDNDConfig> config)
        {
            _config = config.Value;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            if (string.IsNullOrWhiteSpace(_config.DbConnection))
            {
                Log.Fatal("The DbConnection string was not set - this is fatal! Check the config");
            }

            if (string.IsNullOrWhiteSpace(_config.SentryIOToken))
            {
                Log.Warning("The SentryIOToken was not set. SentryIO logging disabled. Check the config.");
            }

            return next;
        }
    }
}