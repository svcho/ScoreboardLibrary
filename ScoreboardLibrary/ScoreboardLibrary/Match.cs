using ScoreboardLibrary.Interfaces;

namespace ScoreboardLibrary
{
    /// <summary>
    /// Represents a sports match between two teams.
    /// </summary>
    public class Match : IMatch
    {
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public bool IsInProgress { get; private set; }
        public int OrderIdentifier { get; }

        /// <summary>
        /// Initializes a new instance of the Match class.
        /// </summary>
        public Match(string homeTeam, string awayTeam, int orderIdentifier)
        {
            if (string.IsNullOrWhiteSpace(homeTeam) || string.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException("Home team and away team names must not be empty.");
            }

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;
            IsInProgress = true;
            OrderIdentifier = orderIdentifier;
        }

        /// <summary>
        /// Updates the scores for the match.
        /// </summary>
        public void UpdateScore(int homeScore, int awayScore)
        {
            if (!IsInProgress)
            {
                throw new InvalidOperationException("Cannot update scores for a finished match.");
            }

            if (homeScore < 0 || awayScore < 0)
            {
                throw new ArgumentOutOfRangeException("Scores cannot be negative.");
            }

            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        /// <summary>
        /// Finishes the match.
        /// </summary>
        public void FinishMatch()
        {
            IsInProgress = false;
        }

        /// <summary>
        /// Gets the total score of the match.
        /// </summary>
        public int GetTotalScore()
        {
            return HomeScore + AwayScore;
        }
    }
}
