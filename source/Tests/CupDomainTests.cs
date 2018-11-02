using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWorldCup.IoC;

namespace MoviesWorldCup.Domain.Tests
{
    [TestClass]
    public class CupDomainTests
    {
        public CupDomainTests()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<ICupDomain, CupDomain>();
            services.AddScoped<IMovieDomain, MovieDomain>();
            services.AddScoped<IMovieService, MovieServiceFake>();

            CupDomain = services.GetService<ICupDomain>();
            MovieService = services.GetService<IMovieService>();
        }

        private ICupDomain CupDomain { get; }

        private IMovieService MovieService { get; }

        [TestMethod]
        public void CupDomainPlay()
        {
            var cupResult = CupDomain.Play(MovieService.List());

            Assert.IsTrue(cupResult.Champion.Rating == 8.8M);
            Assert.IsTrue(cupResult.Vice.Rating == 8.5M);
        }
    }
}
