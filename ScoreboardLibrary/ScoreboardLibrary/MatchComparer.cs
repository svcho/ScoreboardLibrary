using ScoreboardLibrary.Interfaces;

namespace ScoreboardLibrary
{
    /// <summary>
    /// This class implements the IComparer<IMatch> interface to provide custom comparison logic for matches.
    /// </summary>
    public class MatchComparer : IComparer<IMatch>
    {
        /// <summary>
        /// Compares two IMatch objects. The matches with the same total score will be returned 
        /// ordered by the most recently started match in the scoreboard.
        /// </summary>
        public int Compare(IMatch? x, IMatch? y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException("One or both matches are null and cannot be compared.");
            }

            int totalScoreComparison = y.GetTotalScore().CompareTo(x.GetTotalScore());

            if (totalScoreComparison == 0)
            {
                return y.OrderIdentifier.CompareTo(x.OrderIdentifier);
            }

            return totalScoreComparison;
        }
    }
}
