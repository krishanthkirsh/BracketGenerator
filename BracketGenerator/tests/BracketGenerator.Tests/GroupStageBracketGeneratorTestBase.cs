using BracketGenerator.Interfaces;
using BracketGenerator.Models;
using BracketGenerator.Services;
using Moq;
using System.Collections.Generic;

namespace BracketGenerator.Tests
{
    public class GroupStageBracketGeneratorTestBase 
    {
        protected readonly Mock<ISeedData> _mockSeedData;
        protected readonly Mock<IGroupStageService> _mockGroupStageService;
        protected readonly GroupStageBracketGenerator _groupStageBracketGenerator;

        public GroupStageBracketGeneratorTestBase()
        {
            _mockSeedData = new Mock<ISeedData>();
            _mockGroupStageService = new Mock<IGroupStageService>();
            var teams = GroupStageBracketGeneratorTestData.GetTeamsData();
            var tournamentInfo = new TournamentInfo { Teams = teams, GroupSize = 4 };
            _mockSeedData.Setup(s => s.GetGroupStageTournamentInfo()).Returns(tournamentInfo);
            _mockGroupStageService.Setup(s => s.CreateGroupStage(It.Is<List<Team>>(x => x.Count == 16), It.Is<int>(x => x.Equals(4)))).Returns(GroupStageBracketGeneratorTestData.GetFristRoundTeamPair());
            _mockGroupStageService.Setup(s => s.CreateGroupStage(It.Is<List<Team>>(x => x.Count == 8), It.Is<int>(x => x.Equals(4)))).Returns(GroupStageBracketGeneratorTestData.GetSecondRoundTeamPair());
            _mockGroupStageService.Setup(s => s.CreateGroupStage(It.Is<List<Team>>(x => x.Count == 4), It.Is<int>(x => x.Equals(4)))).Returns(GroupStageBracketGeneratorTestData.GetThridRoundTeamPair());
            _mockGroupStageService.Setup(s => s.CreateGroupStage(It.Is<List<Team>>(x => x.Count == 2), It.Is<int>(x => x.Equals(4)))).Returns(GroupStageBracketGeneratorTestData.GetFourthRoundTeamPair());
            _mockGroupStageService.Setup(s => s.GroupMatch(It.Is<List<Team>>(x => MatchList(x, new List<string> { "Netherlands", "USA", "Argentina", "Denmark" }))))
                .Returns(GroupStageBracketGeneratorTestData.GetFirstRoundFirstGroupResult());
            _mockGroupStageService.Setup(x => x.GroupMatch(It.Is<List<Team>>(x => MatchList(x, new List<string> { "Germany", "Canada", "Brazil", "Uruguay" }))))
            .Returns(GroupStageBracketGeneratorTestData.GetFirstRoundSecondGroupResult());
            _mockGroupStageService.Setup(x => x.GroupMatch(It.Is<List<Team>>(x => MatchList(x, new List<string> { "England", "Qatar", "France", "Mexico" }))))
            .Returns(GroupStageBracketGeneratorTestData.GetFirstRoundThridGroupResult());
            _mockGroupStageService.Setup(x => x.GroupMatch(It.Is<List<Team>>(x => MatchList(x, new List<string> { "USA", "Germany", "Mexico", "Portugal" }))))
            .Returns(GroupStageBracketGeneratorTestData.GetFirstRoundFourthGroupResult());

            _groupStageBracketGenerator = new GroupStageBracketGenerator(_mockSeedData.Object, _mockGroupStageService.Object);
        }

        private static bool MatchList(List<Team> teamsList, List<string> checkList)
        {
            bool isMatchList = true;

            foreach (var team in teamsList)
            {
                if (!checkList.Contains(team!.Name!))
                    isMatchList = false;
            }
            return isMatchList;
        }
    }
}
