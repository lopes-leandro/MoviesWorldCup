using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MoviesWorldCup.Web.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfiguration Build(this IHostingEnvironment environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{nameof(AppSettings)}.json")
                .AddJsonFile($"{nameof(AppSettings)}.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
