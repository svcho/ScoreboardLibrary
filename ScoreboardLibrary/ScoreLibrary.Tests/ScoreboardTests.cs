using Xunit;
using ScoreboardLibrary;
using ScoreboardLibrary.Interfaces;

namespace ScoreLibrary.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void TestStartMatch()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();

            // Act
            scoreboard.StartMatch("Mexico", "Canada");
            var match = scoreboard.GetMatchesInProgressOrderedByScore().Single();

            // Assert
            Assert.Equal(0, match.HomeScore);
            Assert.Equal(0, match.AwayScore);
        }

        [Fact]
        public void TestSingleUpdateScore()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");

            // Act
            scoreboard.UpdateScore("Mexico", "Canada", 0, 5);
            var match = scoreboard.GetMatchesInProgressOrderedByScore().Single();

            // Assert
            Assert.Equal(0, match.HomeScore);
            Assert.Equal(5, match.AwayScore);
        }

        [Fact]
        public void TestMultipleUpdatesScore()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");
            var matchesInProgressList = scoreboard.GetMatchesInProgressOrderedByScore().ToList();
            var match = matchesInProgressList[0];

            // Act
            scoreboard.UpdateScore("Mexico", "Canada", 0, 1);
            match = scoreboard.GetMatchesInProgressOrderedByScore().Single();

            // Assert
            Assert.Equal(0, match.HomeScore);
            Assert.Equal(1, match.AwayScore);

            // Act
            scoreboard.UpdateScore("Mexico", "Canada", 1, 1);
            match = scoreboard.GetMatchesInProgressOrderedByScore().Single();

            // Assert
            Assert.Equal(1, match.HomeScore);
            Assert.Equal(1, match.AwayScore);
        }


        [Fact]
        public void TestFinishMatch()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");

            // Act
            scoreboard.FinishMatch("Mexico", "Canada");

            // Assert
            Assert.Empty(scoreboard.GetMatchesInProgressOrderedByScore());
        }

        [Fact]
        public void TestGetMatchesInProgressOrderedByScore()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();

            // Act
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.UpdateScore("Mexico", "Canada", 0, 5);

            scoreboard.StartMatch("Spain", "Brazil");
            scoreboard.UpdateScore("Spain", "Brazil", 10, 2);

            scoreboard.StartMatch("Germany", "France");
            scoreboard.UpdateScore("Germany", "France", 2, 2);

            scoreboard.StartMatch("Uruguay", "Italy");
            scoreboard.UpdateScore("Uruguay", "Italy", 6, 6);

            scoreboard.StartMatch("Argentina", "Australia");
            scoreboard.UpdateScore("Argentina", "Australia", 3, 1);

            var matchesInProgressList = scoreboard.GetMatchesInProgressOrderedByScore().ToList();

            // Assert
            Assert.Equal("Uruguay", matchesInProgressList[0].HomeTeam);
            Assert.Equal(12, matchesInProgressList[0].GetTotalScore());

            Assert.Equal("Spain", matchesInProgressList[1].HomeTeam);
            Assert.Equal(12, matchesInProgressList[1].GetTotalScore());

            Assert.Equal("Mexico", matchesInProgressList[2].HomeTeam);
            Assert.Equal(5, matchesInProgressList[2].GetTotalScore());

            Assert.Equal("Argentina", matchesInProgressList[3].HomeTeam);
            Assert.Equal(4, matchesInProgressList[3].GetTotalScore());

            Assert.Equal("Germany", matchesInProgressList[4].HomeTeam);
            Assert.Equal(4, matchesInProgressList[4].GetTotalScore());
        }

        [Fact]
        public void TestUpdateScoreMatchNotInProgress()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.FinishMatch("Mexico", "Canada");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => scoreboard.UpdateScore("Spain", "Brazil", 10, 2));
        }

        [Fact]
        public void TestUpdateScoreNegativeScores()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoreboard.UpdateScore("Mexico", "Canada", -1, 5));
            Assert.Throws<ArgumentOutOfRangeException>(() => scoreboard.UpdateScore("Mexico", "Canada", 0, -5));
        }

        [Fact]
        public void TestFinishMatchMatchNotFound()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => scoreboard.FinishMatch("Mexico", "Canada"));
        }

        [Fact]
        public void TestStartMatchEmptyTeamNames()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => scoreboard.StartMatch("Mexico", ""));
            Assert.Throws<ArgumentException>(() => scoreboard.StartMatch("", "Canada"));
            Assert.Throws<ArgumentException>(() => scoreboard.StartMatch("", ""));
        }

        [Fact]
        public void TestGetMatchesInProgressNoMatches()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();

            // Act
            var matchesInProgress = scoreboard.GetMatchesInProgressOrderedByScore();

            // Assert
            Assert.Empty(matchesInProgress);
        }

        [Fact]
        public void TestStartMatchesWithTheSameName()
        {
            // Arrange
            IScoreboard scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");

            // Act
            var matchesInProgress = scoreboard.GetMatchesInProgressOrderedByScore();

            // Assert
            Assert.Throws<InvalidOperationException>(() => scoreboard.StartMatch("Mexico", "Canada"));
        }
    }
}
