using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoviesWorldCup.IoC;
using Newtonsoft.Json;

namespace MoviesWorldCup.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();

            services.Configure<AppSettings>(configuration);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);
            var appSettings = services.BuildServiceProvider().GetRequiredService<AppSettings>();

            services.AddMovieService(appSettings.MovieServiceUri);
        }

        public static void AddMvcJson(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
        }

        public static void AddSpaStaticFiles(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(config => config.RootPath = "Frontend/dist");
        }
    }
}
