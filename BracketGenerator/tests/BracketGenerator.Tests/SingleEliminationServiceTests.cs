using BracketGenerator.Models;
using BracketGenerator.Services;
using System.Collections.Generic;
using Xunit;

namespace BracketGenerator.Tests
{
    public class SingleEliminationServiceTests : BaseTest
    {
        private readonly SingleEliminationService _singleEliminationservice;

        public SingleEliminationServiceTests()
        {
            _singleEliminationservice = new SingleEliminationService();
        }

        [Fact]
        public void CreateGroup_Pairs_As_Group()
        {
            var teams = GetTeamsData();

            var groups = _singleEliminationservice.CreateGroup(teams);

            Assert.Equal(2, groups.Count);
        }
        [Fact]
        public void SingaleMatchWithPredefinedWinner_ReturnTeamAWinner()
        {
            var teamA = new Team { Name = "Germany" };
            var teamB = new Team { Name = "England" };
            var match = new Match { TeamA = teamA, TeamB = teamB };

            var result = _singleEliminationservice.SingaleMatchWithPredefinedWinner(match, AdvanceEventsModel?.Events);

            Assert.True(result == teamA);
        }

        [Fact]
        public void SingaleMatchWithPredefinedWinner_ReturnTeamBWinner()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Brazil" };
            var match = new Match { TeamA = teamA, TeamB = teamB };

            var result = _singleEliminationservice.SingaleMatchWithPredefinedWinner(match, AdvanceEventsModel?.Events);

            Assert.True(result == teamB);
        }

        [Fact]
        public void SingaleMatchWithPredefinedWinner_ReturnWinner()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Mexico" };
            var match = new Match { TeamA = teamA, TeamB = teamB };

            var result = _singleEliminationservice.SingaleMatchWithPredefinedWinner(match, AdvanceEventsModel?.Events);

            Assert.True(result == teamB || result == teamA);
        }

        [Fact]
        public void SetWinningTeam_SetWinnerAndRemoveFromList()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Mexico" };
            var match = new Match { TeamA = teamA, TeamB = teamB };
            var winningTeam = new List<string> { "England" };

            _singleEliminationservice.SetWinningTeam(match, teamA, winningTeam);

            Assert.DoesNotContain("England", winningTeam);
        }

        [Fact]
        public void SingaleMatch_ReturnRandomTeam()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Mexico" };
            var match = new Match { TeamA = teamA, TeamB = teamB };

            var result = _singleEliminationservice.SingaleMatch(match);
            Assert.True(result == teamA || result == teamB); 
        }



        public static List<Team> GetTeamsData()
        {
            var teams = new List<Team>
            {
                new() { Name = "England" },
                new() { Name = "Brazil" },
                new() { Name = "Canada" },
                new() { Name = "Netherland" }
            };

            return teams;
        }

    }
}
