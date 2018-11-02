using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWorldCup.IoC;
using System.Linq;

namespace MoviesWorldCup.Domain.Tests
{
    [TestClass]
    public class MovieDomainTests
    {
        public MovieDomainTests()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IMovieDomain, MovieDomain>();
            services.AddScoped<IMovieService, MovieServiceFake>();

            MovieDomain = services.GetService<IMovieDomain>();
            MovieService = services.GetService<IMovieService>();
        }

        private IMovieDomain MovieDomain { get; }

        private IMovieService MovieService { get; }

        [TestMethod]
        public void MovieDomainListSelected()
        {
            var selected = MovieDomain.ListSelected(MovieService.List()).ToList();

            Assert.IsTrue(selected.Any());
        }
    }
}
