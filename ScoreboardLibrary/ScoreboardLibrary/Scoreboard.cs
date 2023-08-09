using ScoreboardLibrary.Interfaces;

namespace ScoreboardLibrary
{
    /// <summary>
    /// Represents a scoreboard that manages sports matches and their scores.
    /// </summary>
    public class Scoreboard : IScoreboard
    {
        private readonly List<Match> matches = new();
        private int matchCounter = 0; // Counter for unique order identification

        /// <summary>
        /// Gets a list of matches in progress, ordered by score.
        /// </summary>
        public void StartMatch(string homeTeam, string awayTeam)
        {
            ValidateTeamNames(homeTeam, awayTeam);

            // Check if a match between the same teams is already in progress.
            if (FindMatchInProgress(homeTeam, awayTeam) != null)
            {
                throw new InvalidOperationException("A match between the same teams is already in progress.");
            }

            // Create and add a new match to the list.
            var match = new Match(homeTeam, awayTeam, matchCounter++);
            matches.Add(match);
        }

        /// <summary>
        /// Updates the scores of a match in progress.
        /// </summary>
        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            var match = FindMatchInProgress(homeTeam, awayTeam);

            if (match != null)
            {
                match.UpdateScore(homeScore, awayScore);
            }
            else
            {
                throw new InvalidOperationException("No match in progress found for the provided teams.");
            }
        }

        /// <summary>
        /// Finishes a match in progress.
        /// </summary>
        public void FinishMatch(string homeTeam, string awayTeam)
        {
            var match = FindMatchInProgress(homeTeam, awayTeam);

            if (match != null)
            {
                match.FinishMatch();
                matches.Remove(match);
            }
            else 
            {
                throw new InvalidOperationException("No match is currently in progress for the provided teams.");
            }
        }

        /// <summary>
        /// Gets a list of matches in progress, ordered by score. If the score is the same the most recently started game is the first match.
        /// </summary>
        public IEnumerable<IMatch> GetMatchesInProgressOrderedByScore()
        {
            // Sort matches based on total score and unique order identifier.
            matches.Sort(new MatchComparer());
            // Return only the matches that are still in progress.
            return matches.Where(match => match.IsInProgress).ToList();
        }

        // ... Other private methods and fields ...

        /// <summary>
        /// Return the matches in progress for the given home and away team or null if the game is not in progress or does not exist.
        /// </summary>
        private Match? FindMatchInProgress(string homeTeam, string awayTeam)
        {
            ValidateTeamNames(homeTeam, awayTeam);

            return matches.FirstOrDefault(m =>
                m.HomeTeam == homeTeam && m.AwayTeam == awayTeam && m.IsInProgress);
        }

        /// <summary>
        /// Validation method to ensure team names are not empty.
        /// </summary>
        private void ValidateTeamNames(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrWhiteSpace(homeTeam) || string.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException("Home team and away team names must not be empty.");
            }
        }
    }
}