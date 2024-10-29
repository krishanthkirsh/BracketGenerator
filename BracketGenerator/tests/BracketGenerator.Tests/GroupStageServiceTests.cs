using BracketGenerator.Models;
using BracketGenerator.Services;
using System.Collections.Generic;
using Xunit;

namespace BracketGenerator.Tests
{
    public class GroupStageServiceTests : BaseTest
    {
        private readonly GroupStageService _groupStageService;

        public GroupStageServiceTests() 
        {
            _groupStageService = new GroupStageService();
        }

        [Fact]
        public void CreateGroupStage_Success()
        {
            var teams = GetTeamsData();
            int groupSize = 4;

            var result = _groupStageService.CreateGroupStage(teams, groupSize);

            Assert.Single(result); 
            Assert.All(result, group => Assert.Equal(groupSize, group.Count)); 
        }

        [Fact]
        public void GroupMatch_Success()
        {
            var group = GetTeamsData();
            var (winningTeams, roundsMatch) = _groupStageService.GroupMatch(group);

            Assert.Equal(2, winningTeams.Count);
            Assert.Equal(2, roundsMatch.Count); 
        }

        [Fact]
        public void SingaleMatch_ReturnRandomTeam()
        {
            var teamA = new Team { Name = "England" };
            var teamB = new Team { Name = "Mexico" };
            var match = new Match { TeamA = teamA, TeamB = teamB };

            var result = _groupStageService.SingaleMatch(match);
            Assert.True(result == teamA || result == teamB);
        }

        [Fact]
        public void SingaleMatch_TeamsisNull()
        {
            var match = new Match { TeamA = null, TeamB = null };
            var winner = _groupStageService.SingaleMatch(match);

            Assert.NotNull(winner); 
            Assert.Null(winner.Name); 
        }

        private static List<Team> GetTeamsData()
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
