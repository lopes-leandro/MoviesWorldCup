using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace MoviesWorldCup.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSpa(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseSpa(config =>
            {
                config.Options.SourcePath = "Frontend";

                if (environment.IsDevelopment())
                {
                    config.UseAngularCliServer("serve");
                }
            });
        }
    }
}
