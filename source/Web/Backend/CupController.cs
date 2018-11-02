using Microsoft.AspNetCore.Mvc;
using MoviesWorldCup.Domain;
using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Web
{
    [ApiController]
    [Route("[controller]")]
    public class CupController : ControllerBase
    {
        public CupController(ICupDomain cupDomain)
        {
            CupDomain = cupDomain;
        }

        private ICupDomain CupDomain { get; }

        [HttpPost]
        public CupResult Post([FromBody] IList<Movie> selected)
        {
            return CupDomain.Play(selected);
        }
    }
}
