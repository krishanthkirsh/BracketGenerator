using BracketGenerator.Models;
using System.Collections.Generic;


namespace BracketGenerator.Tests
{
    public static class GroupStageBracketGeneratorTestData
    {
        public static List<List<Team>> GetFourthRoundTeamPair()
        {
            var fouthRoundGroups = new List<List<Team>>();

            fouthRoundGroups.Add(new List<Team>
            {
             new (){ Name ="Germany"},
             new (){ Name ="Mexico"}
            });


            return fouthRoundGroups;
        }
        public static List<List<Team>> GetThridRoundTeamPair()
        {
            var thirdRoundGroups = new List<List<Team>>();

            thirdRoundGroups.Add(new List<Team>
            {
             new (){ Name ="USA"},
             new (){ Name ="Germany"},
             new (){ Name ="Mexico"},
             new (){ Name ="Portugal"}
            });

            return thirdRoundGroups;
        }
        public static List<List<Team>> GetSecondRoundTeamPair()
        {
            var secoundRoundGroups = new List<List<Team>>();

            secoundRoundGroups.Add(new List<Team>
            {
             new (){ Name ="USA"},
             new (){ Name ="Denmark"},
             new (){ Name ="Germany"},
             new (){ Name ="Uruguay"}
            });

            secoundRoundGroups.Add(new List<Team>
            {
             new (){ Name ="England"},
             new (){ Name ="Mexico"},
             new (){ Name ="Belgium"},
             new (){ Name ="Portugal"}
            });

            return secoundRoundGroups;
        }
        public static List<List<Team>> GetFristRoundTeamPair()
        {
            var firstRoundGroups = new List<List<Team>>();

            firstRoundGroups.Add(new List<Team>
            {
             new (){ Name ="Netherlands"},
             new (){ Name ="USA"},
             new (){ Name ="Argentina"},
             new (){ Name ="Denmark"}
            });

            firstRoundGroups.Add(new List<Team>
            {
             new (){ Name ="Germany"},
             new (){ Name ="Canada"},
             new (){ Name ="Brazil"},
             new (){ Name ="Uruguay"}
            });

            firstRoundGroups.Add(new List<Team>
            {
             new (){ Name ="England"},
             new (){ Name ="Qatar"},
             new (){ Name ="France"},
             new (){ Name ="Mexico"}
            });

            firstRoundGroups.Add(new List<Team>
            {
             new (){ Name ="Belgium"},
             new (){ Name ="Japan"},
             new (){ Name ="Portugal"},
             new (){ Name ="Cameroon"}
            });

            return firstRoundGroups;
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
        public static (List<Team> winners, List<BracketGenerator.Models.Match> matchs) GetFirstRoundFirstGroupResult()
        {
            var winners = new List<Team>
            { new() { Name = "USA" },
              new() { Name = "Denmark" }
            };

            var machers = new List<BracketGenerator.Models.Match>
            {
                new() { TeamA = new Team { Name = "Netherlands" },
                  TeamB = new Team { Name = "USA" },
                  Winner = new Team { Name = "USA" }
                },
                new() { TeamA = new Team { Name = "Argentina" },
                    TeamB = new Team { Name = "Denmark" },
                    Winner = new Team { Name = "Denmark" } }
            };

            return (winners, machers);
        }
        public static (List<Team> winners, List<BracketGenerator.Models.Match> matchs) GetFirstRoundSecondGroupResult()
        {
            var winners = new List<Team>
            {
            new () { Name = "Germany" }
        ,   new () { Name = "Uruguay" }
            };

            var machers = new List<BracketGenerator.Models.Match>
            {
                new ()
                {  TeamA = new Team { Name = "Germany" },
                   TeamB = new Team { Name = "Canada" },
                   Winner = new Team { Name = "Germany" }
                },
                new ()
                {
                    TeamA = new Team { Name = "Brazil" },
                    TeamB = new Team { Name = "Uruguay" },
                    Winner = new Team { Name = "Uruguay" }
                }
            };

            return (winners, machers);
        }
        public static (List<Team> winners, List<BracketGenerator.Models.Match> matchs) GetFirstRoundThridGroupResult()
        {
            var winners = new List<Team>
            { new () { Name = "England" },
              new () { Name = "Mexico" }
            };

            var machers = new List<BracketGenerator.Models.Match>
            {
                new ()
                {
                    TeamA = new Team { Name = "England" },
                    TeamB = new Team { Name = "Qatar" },
                    Winner = new Team { Name = "England" }
                },
                 new ()
                 {
                     TeamA = new Team { Name = "France" },
                     TeamB = new Team { Name = "Mexico" },
                     Winner = new Team { Name = "Mexico" }
                 }
            };

            return (winners, machers);
        }
        public static (List<Team> winners, List<BracketGenerator.Models.Match> matchs) GetFirstRoundFourthGroupResult()
        {
            var winners = new List<Team>
            {
                new() { Name = "Belgium" },
                new() { Name = "Portugal" }
            };

            var machers = new List<BracketGenerator.Models.Match>
            {
                new()
                {
                    TeamA = new Team { Name = "Belgium" },
                    TeamB = new Team { Name = "Japan" },
                    Winner = new Team { Name = "Belgium" }
                },
                new()
                 {
                    TeamA = new Team { Name = "Portugal" },
                    TeamB = new Team { Name = "Cameroon" },Winner = new Team { Name = "Portugal" }
                }
            };

            return (winners, machers);
        }
    }
}
