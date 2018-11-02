using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Domain
{
    public interface IMovieService
    {
        IList<Movie> List();
    }
}
