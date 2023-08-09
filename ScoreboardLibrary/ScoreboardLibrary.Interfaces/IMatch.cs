namespace ScoreboardLibrary.Interfaces
{
    /// <summary>
    /// Represents a sports match between two teams.
    /// </summary>
    public interface IMatch
    {
        /// <summary>
        /// Gets the name of the home team.
        /// </summary>
        string HomeTeam { get; }

        /// <summary>
        /// Gets the name of the away team.
        /// </summary>
        string AwayTeam { get; }

        /// <summary>
        /// Gets the score of the home team.
        /// </summary>
        int HomeScore { get; }

        /// <summary>
        /// Gets the score of the away team.
        /// </summary>
        int AwayScore { get; }

        /// <summary>
        /// Gets whether the match is currently in progress.
        /// </summary>
        bool IsInProgress { get; }

        /// <summary>
        /// Gets a unique identifier for the match's order.
        /// </summary>
        public int OrderIdentifier { get; }

        /// <summary>
        /// Updates the scores of the match.
        /// </summary>
        /// <param name="homeScore">The updated score of the home team.</param>
        /// <param name="awayScore">The updated score of the away team.</param>
        void UpdateScore(int homeScore, int awayScore);

        /// <summary>
        /// Finishes the match.
        /// </summary>
        void FinishMatch();

        /// <summary>
        /// Gets the total score of the match (sum of home and away scores).
        /// </summary>
        /// <returns>The total score of the match.</returns>
        int GetTotalScore();
    }
}
