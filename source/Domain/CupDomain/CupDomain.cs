using MoviesWorldCup.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesWorldCup.Domain
{
    public class CupDomain : ICupDomain
    {
        public CupDomain(IMovieDomain movieDomain)
        {
            MovieDomain = movieDomain;
        }

        public IMovieDomain MovieDomain { get; }

        public CupResult Play(IList<Movie> selected)
        {
            var participants = MovieDomain.ListSelected(selected);
            var stagesResults = PlayStages(participants);
            var lastMatchResult = stagesResults.Last().MatchesResults.Last();

            return new CupResult(lastMatchResult.Winner, lastMatchResult.Loser);
        }

        private IList<MatchResult> PlayMatches(IList<Movie> participants)
        {
            var matchesResults = new List<MatchResult>();

            var matches = participants.Count / 2;

            for (var i = 0; i < matches; i++)
            {
                var j = participants.Count - (i + 1);
                var winner = participants[i].Rating >= participants[j].Rating ? participants[i] : participants[j];
                var loser = winner == participants[i] ? participants[j] : participants[i];
                matchesResults.Add(new MatchResult(winner, loser));
            }

            return matchesResults;
        }

        private IEnumerable<StageResult> PlayStages(IList<Movie> participants)
        {
            var stagesResults = new List<StageResult>();

            while (participants.Count > 1)
            {
                var matchesResults = PlayMatches(participants);
                stagesResults.Add(new StageResult(matchesResults));
                participants = matchesResults.Select(x => x.Winner).ToList();
            }

            return stagesResults;
        }
    }
}
