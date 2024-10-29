using System.Linq;
using Xunit;

namespace BracketGenerator.Tests
{
    public class GroupStageBracketGeneratorTest : GroupStageBracketGeneratorTestBase
    {
        [Fact]
        public void CreateTournamentBracket_Success()
        {
            var groupStageTournament = _groupStageBracketGenerator.CreateTournamentBracket();

            Assert.NotNull(groupStageTournament);
            Assert.Equal(2, groupStageTournament.Count);
            Assert.Equal("Portugal", groupStageTournament.Last().Winner!.Name);

        }

        [Fact]

        public void GetTournamentWinning_Team()
        {
            _groupStageBracketGenerator.CreateTournamentBracket();
            var team = _groupStageBracketGenerator.GetTournamentWinner();
            Assert.NotNull(team);
            Assert.Equal("Portugal", team?.Name);

        }

        [Fact]

        public void Get_Tournament_Victory_Path()
        {
            _groupStageBracketGenerator.CreateTournamentBracket();
            var victoryPath = _groupStageBracketGenerator.PathToVictory();

            Assert.NotNull(victoryPath);
            Assert.Single(victoryPath);

        }
    }
}
