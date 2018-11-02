using MoviesWorldCup.Domain;
using MoviesWorldCup.Model;
using System.Collections.Generic;

namespace MoviesWorldCup.Domain
{
    public class MovieServiceFake : IMovieService
    {
        public IList<Movie> List()
        {
            return new List<Movie>
            {
                new Movie { Year = 2018, Id = "tt3606756", Rating = 8.5M, Title = "Os Incríveis 2" },
                new Movie { Year = 2018, Id = "tt4881806", Rating = 6.7M, Title = "Jurassic World: Reino Ameaçado" },
                new Movie { Year = 2018, Id = "tt5164214", Rating = 6.3M, Title = "Oito Mulheres e um Segredo" },
                new Movie { Year = 2018, Id = "tt7784604", Rating = 7.8M, Title = "Hereditário" },
                new Movie { Year = 2018, Id = "tt4154756", Rating = 8.8M, Title = "Vingadores: Guerra Infinita" },
                new Movie { Year = 2018, Id = "tt5463162", Rating = 8.1M, Title = "Deadpool 2" },
                new Movie { Year = 2018, Id = "tt3778644", Rating = 7.2M, Title = "Han Solo: Uma História Star Wars" },
                new Movie { Year = 2018, Id = "tt3501632", Rating = 7.9M, Title = "Thor: Ragnarok" }
            };
        }
    }
}
