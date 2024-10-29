using BracketGenerator.Models;
using System.Collections.Generic;
using Xunit;

namespace BracketGenerator.Tests
{
    public class SingleEliminationBracketGeneratorTests: SingleEliminationBracketGeneratorTestBase
    {

        [Fact]
        public void CreateTournamentBracket_Success()
        {
            var result = _singleEliminationBracketGenerator.CreateTournamentBracket();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetTournamentWinner_ReturnFinalWinner()
        {
            _singleEliminationBracketGenerator.TeamBracket.Add(new Match() { TeamA = new Team() { Name = "Japan" }, TeamB = new Team() { Name = "Canada" }, Winner = new Team() { Name = "Canada" } });
            var winner = _singleEliminationBracketGenerator.GetTournamentWinner();

            Assert.Equal("Canada", winner?.Name);
        }

        [Fact]
        public void PathToVictory_ShouldReturnWinningPath()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Brazil" };
            var teamC = new Team { Name = "Canada" };
            var teamD = new Team { Name = "Netherland" };

            var match1 = new BracketGenerator.Models.Match { TeamA = teamA, TeamB = teamB, Winner = teamA };
            var match2 = new BracketGenerator.Models.Match { TeamA = teamC, TeamB = teamD, Winner = teamC };
            var match3 = new BracketGenerator.Models.Match { TeamA = teamA, TeamB = teamC, Winner = teamA };

            _singleEliminationBracketGenerator.TeamBracket.AddRange(new List<BracketGenerator.Models.Match> { match1, match2, match3 });

            var path = _singleEliminationBracketGenerator.PathToVictory();

            Assert.Equal(2, path.Count);
        }

        [Fact]
        public void InitializeTournamentData_ShouldLoadDataFromSeed()
        {
            var teams = new List<Team> { new Team { Name = "Team A" }, new Team { Name = "Team B" } };
            var winners = new List<string> { "Team A" };
            var tournamentInfo = new TournamentInfo { Teams = teams, Winners = winners };

            _mockSeedData.Setup(sd => sd.GetSingleEliminationTournamentInfo()).Returns(tournamentInfo);

            _singleEliminationBracketGenerator.CreateTournamentBracket();
            Assert.Equal(winners, _singleEliminationBracketGenerator.Winners);
        }
    }
}
