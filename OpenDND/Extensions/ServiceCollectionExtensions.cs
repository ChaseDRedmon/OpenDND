using Microsoft.Extensions.DependencyInjection;
using OpenDND.DiscordBot;

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
            services.AddSingleton<DiscordSerilogAdapter>();
            services.AddHostedService<OpenDndBot>();
            
            return services;
        }
    }
}