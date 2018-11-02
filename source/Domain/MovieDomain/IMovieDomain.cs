using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Domain
{
    public interface IMovieDomain
    {
        IList<Movie> List();

        IList<Movie> ListSelected(IList<Movie> selected);
    }
}
