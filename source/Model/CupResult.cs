namespace MoviesWorldCup.Model
{
    public sealed class CupResult
    {
        public CupResult(Movie champion, Movie vice)
        {
            Champion = champion;
            Vice = vice;
        }

        public Movie Champion { get; set; }

        public Movie Vice { get; set; }
    }
}
