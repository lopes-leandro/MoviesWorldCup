using MoviesWorldCup.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesWorldCup.Domain
{
    public class MovieDomain : IMovieDomain
    {
        public MovieDomain(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public IMovieService MovieService { get; }

        public IList<Movie> List()
        {
            return MovieService.List();
        }

        public IList<Movie> ListSelected(IList<Movie> selected)
        {
            return List()
                .Where(movie => selected.Any(selectedMovie => selectedMovie.Id == movie.Id))
                .OrderBy(movie => movie.Title).ToList();
        }
    }
}
