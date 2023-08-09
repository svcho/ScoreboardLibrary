namespace ScoreboardLibrary.Interfaces
{
    /// <summary>
    /// Represents a scoreboard that manages sports matches and their scores.
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Starts a new match between the specified home and away teams.
        /// </summary>
        /// <param name="homeTeam">The name of the home team.</param>
        /// <param name="awayTeam">The name of the away team.</param>
        void StartMatch(string homeTeam, string awayTeam);

        /// <summary>
        /// Updates the scores for an ongoing match between the specified teams.
        /// </summary>
        /// <param name="homeTeam">The name of the home team.</param>
        /// <param name="awayTeam">The name of the away team.</param>
        /// <param name="homeScore">The updated score of the home team.</param>
        /// <param name="awayScore">The updated score of the away team.</param>
        void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore);

        /// <summary>
        /// Finishes an ongoing match between the specified teams.
        /// </summary>
        /// <param name="homeTeam">The name of the home team.</param>
        /// <param name="awayTeam">The name of the away team.</param>
        void FinishMatch(string homeTeam, string awayTeam);

        /// <summary>
        /// Gets a collection of matches that are currently in progress, ordered by their scores.
        /// </summary>
        /// <returns>An enumerable collection of ongoing matches ordered by score.</returns>
        IEnumerable<IMatch> GetMatchesInProgressOrderedByScore();
    }
}
