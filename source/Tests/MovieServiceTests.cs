using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWorldCup.IoC;
using System.Linq;

namespace MoviesWorldCup.Domain.Tests
{
    [TestClass]
    public class MovieServiceTests
    {
        public MovieServiceTests()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IMovieService, MovieServiceFake>();
            MovieService = services.GetService<IMovieService>();
        }

        private IMovieService MovieService { get; }

        [TestMethod]
        public void MovieServiceList()
        {
            Assert.IsTrue(MovieService.List().Any());
        }
    }
}
