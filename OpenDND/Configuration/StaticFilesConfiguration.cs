using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace OpenDND.Configuration
{
    public class StaticFilesConfiguration : IConfigureOptions<StaticFileOptions>
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IHostingEnvironment _env;

        public StaticFilesConfiguration(IAntiforgery antiforgery, IHostingEnvironment env)
        {
            _antiforgery = antiforgery;
            _env = env;
        }

        public void Configure(StaticFileOptions options)
        {
            var cachePeriod = _env.IsDevelopment() ? "600" : "604800";

            //Set up our _antiforgery stuff when the user hits the page
            options.OnPrepareResponse =
                fileResponse =>
                {
                    if (fileResponse.File.Name == "index.html")
                    {
                        var tokens = _antiforgery.GetAndStoreTokens(fileResponse.Context);

                        fileResponse.Context.Response.Cookies.Append(
                            "XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
                    }

                    fileResponse.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                };
        }
    }
}