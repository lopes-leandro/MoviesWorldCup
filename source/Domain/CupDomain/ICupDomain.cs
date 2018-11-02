using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Domain
{
    public interface ICupDomain
    {
        CupResult Play(IList<Movie> selected);
    }
}
