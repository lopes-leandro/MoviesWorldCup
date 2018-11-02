namespace MoviesWorldCup.Model
{
    public sealed class MatchResult
    {
        public MatchResult(Movie winner, Movie loser)
        {
            Winner = winner;
            Loser = loser;
        }

        public Movie Loser { get; set; }

        public Movie Winner { get; set; }
    }
}
