using System.Collections.Generic;

namespace MoviesWorldCup.Model
{
    public class StageResult
    {
        public StageResult(IList<MatchResult> matchesResults)
        {
            MatchesResults = matchesResults;
        }

        public IList<MatchResult> MatchesResults { get; set; }
    }
}
