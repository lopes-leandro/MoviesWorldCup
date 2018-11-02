using Microsoft.AspNetCore.Mvc;
using MoviesWorldCup.Domain;
using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Web
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public MovieController(IMovieDomain movieDomain)
        {
            MovieDomain = movieDomain;
        }

        private IMovieDomain MovieDomain { get; }

        [HttpGet]
        [ResponseCache(Duration = 600)]
        public IList<Movie> Get()
        {
            return MovieDomain.List();
        }
    }
}
