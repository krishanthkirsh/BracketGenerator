using BracketGenerator.Interfaces;
using BracketGenerator.Models;
using BracketGenerator.Services;
using Moq;
using System.Collections.Generic;

namespace BracketGenerator.Tests
{
    public class SingleEliminationBracketGeneratorTestBase
    {
        protected readonly Mock<ISeedData> _mockSeedData;
        protected readonly Mock<ISingleEliminationService> _mockSingleEliminationService;
        protected readonly SingleEliminationBracketGenerator _singleEliminationBracketGenerator;

        public SingleEliminationBracketGeneratorTestBase()
        {
            _mockSeedData = new Mock<ISeedData>();
            _mockSingleEliminationService = new Mock<ISingleEliminationService>();
            var teams = GetTeamsData();
            var tournamentInfo = new TournamentInfo { Teams = teams, Winners = new List<string>() { "France", "Netherlands", "Argentina", "Brazil", "France", "Argentina", "Qatar", "Brazil", "Germany", "Japan", "Brazil", "Portugal", "Japan", "Japan", "Brazil" } };
            _mockSeedData.Setup(s => s.GetSingleEliminationTournamentInfo()).Returns(tournamentInfo);
            _mockSingleEliminationService.Setup(s => s.CreateGroup(It.Is<List<Team>>(x => x.Count == 16))).Returns(GetFristRoundTeamPair());
            _mockSingleEliminationService.Setup(s => s.CreateGroup(It.Is<List<Team>>(x => x.Count == 8))).Returns(GetSecondRoundTeamPair());
            _mockSingleEliminationService.Setup(s => s.CreateGroup(It.Is<List<Team>>(x => x.Count == 4))).Returns(GetThridRoundTeamPair());
            _mockSingleEliminationService.Setup(s => s.CreateGroup(It.Is<List<Team>>(x => x.Count == 2))).Returns(GetFourthRoundTeamPair());
            _mockSingleEliminationService.Setup(m => m.SingaleMatchWithPredefinedWinner(It.Is<BracketGenerator.Models.Match>(x => x.TeamA!.Name!.Equals("Germany") && x.TeamB!.Name!.Equals("Canada")), It.IsAny<List<string>>()))
                .Returns(new Team() { Name = "Germany", Seed = "1A" });
            _mockSingleEliminationService.Setup(m => m.SingaleMatchWithPredefinedWinner(It.Is<BracketGenerator.Models.Match>(x => x.TeamA!.Name!.Equals("Netherlands") && x.TeamB!.Name!.Equals("USA")), It.IsAny<List<string>>()))
                .Returns(new Team() { Name = "Netherlands" });
            _mockSingleEliminationService.Setup(m => m.SingaleMatchWithPredefinedWinner(It.Is<BracketGenerator.Models.Match>(x => x.TeamA!.Name!.Equals("France") && x.TeamB!.Name!.Equals("Japan")), It.IsAny<List<string>>()))
                .Returns(new Team() { Name = "Japan" });
            _mockSingleEliminationService.Setup(m => m.SingaleMatchWithPredefinedWinner(It.Is<BracketGenerator.Models.Match>(x => x.TeamA!.Name!.Equals("Argentina") && x.TeamB!.Name!.Equals("Brazil")), It.IsAny<List<string>>()))
                .Returns(new Team() { Name = "Brazil" });
            _mockSingleEliminationService.Setup(m => m.SingaleMatchWithPredefinedWinner(It.Is<BracketGenerator.Models.Match>(x => x.TeamA!.Name!.Equals("Brazil") && x.TeamB!.Name!.Equals("Japan")), It.IsAny<List<string>>()))
                .Returns(new Team() { Name = "Brazil" });

            _singleEliminationBracketGenerator = new SingleEliminationBracketGenerator(_mockSeedData.Object, _mockSingleEliminationService.Object);
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


        private static List<List<Team>> GetFristRoundTeamPair()
        {
            var teamPairList = new List<List<Team>>();

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Netherlands"},
             new Team() { Name ="USA"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Argentina"},
             new Team() { Name ="Denmark"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Germany"},
             new Team() { Name ="Canada"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Brazil"},
             new Team() { Name ="Uruguay"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="England"},
             new Team() { Name ="Qatar"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="France"},
             new Team() { Name ="Mexico"},
            });

            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Belgium"},
             new Team() { Name ="Japan"},
            });
            teamPairList.Add(new List<Team>()
            {
             new Team() { Name ="Portugal"},
             new Team() { Name ="Cameroon"},
            });

            return teamPairList;
        }
        private static List<List<Team>> GetSecondRoundTeamPair()
        {
            var teamPairList = new List<List<Team>>();

            teamPairList.Add(new List<Team>()
            {
             new() {Name ="Netherlands"},
             new() {Name ="Argentina"},
            });

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="Germany"},
             new() { Name ="Brazil"},
            });

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="Qatar"},
             new() { Name ="France"},
            });

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="Japan"},
             new() { Name ="Portugal"},
            });

            return teamPairList;
        }
        private static List<List<Team>> GetThridRoundTeamPair()
        {
            var teamPairList = new List<List<Team>>();

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="Argentina"},
             new() { Name ="Brazil"},
            });

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="France"},
             new() { Name ="Japan"},
            });

            return teamPairList;
        }
        private static List<List<Team>> GetFourthRoundTeamPair()
        {
            var teamPairList = new List<List<Team>>();

            teamPairList.Add(new List<Team>()
            {
             new() { Name ="Brazil"},
             new() { Name ="Japan"},
            });


            return teamPairList;
        }
    }
}
