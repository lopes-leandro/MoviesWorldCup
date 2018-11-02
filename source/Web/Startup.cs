using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesWorldCup.Web.Extensions;

namespace MoviesWorldCup.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = environment.Build();
            Environment = environment;
        }

        private IConfiguration Configuration { get; }

        private IHostingEnvironment Environment { get; }

        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.UseMvcWithDefaultRoute();
            application.UseResponseCaching();
            application.UseSpa(Environment);
            application.UseSpaStaticFiles();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection(Configuration);
            services.AddMvcJson();
            services.AddResponseCaching();
            services.AddSpaStaticFiles();
        }
    }
}
