using Microsoft.Extensions.DependencyInjection;
using MoviesWorldCup.Domain;

namespace MoviesWorldCup.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMovieService(this IServiceCollection services, string movieServiceUri)
        {
            services.AddScoped<IMovieService>(_ => new MovieService(movieServiceUri));
        }

        public static T GetService<T>(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetRequiredService<T>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICupDomain, CupDomain>();
            services.AddScoped<IMovieDomain, MovieDomain>();
        }
    }
}
