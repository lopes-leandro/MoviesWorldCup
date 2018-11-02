using MoviesWorldCup.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MoviesWorldCup.Domain
{
    public class MovieService : IMovieService
    {
        public MovieService(string movieServiceUri)
        {
            MovieServiceUri = movieServiceUri;
        }

        private string MovieServiceUri { get; }

        public IList<Movie> List()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(MovieServiceUri).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<MovieResponse>>(content);

                return result.Select(MapToMovie()).ToList();
            }
        }

        private static Func<MovieResponse, Movie> MapToMovie()
        {
            return x => new Movie
            {
                Id = x.Id,
                Year = x.Ano,
                Rating = x.Nota,
                Title = x.Titulo
            };
        }
    }
}
