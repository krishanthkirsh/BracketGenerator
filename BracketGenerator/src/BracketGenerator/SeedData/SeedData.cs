using BracketGenerator.Helper;
using BracketGenerator.Interfaces;
using BracketGenerator.Models;

namespace BracketGenerator.SeedData
{
    public class SeedData : ISeedData
    {
        private const string _tournamentName = "2022 FIFA World Cup";
        public SeedData()
        {
            Teams = new List<Team>();
            Winners = new List<string>();
            SeedTeamData();
            SetWinners();
        }
        public static List<Team>? Teams { get; set; }
        public static List<string>? Winners { get; set; }

        public TournamentInfo GetSingleEliminationTournamentInfo() => new() { TournamentName = _tournamentName, Teams = Teams, Winners = Winners };

        public TournamentInfo GetGroupStageTournamentInfo() => new() { TournamentName = _tournamentName, Teams = Teams, GroupSize = 4 };

        private Team SeedTeam(string seed, string name)
        {
            return new Team { Seed = seed, Name = name };
        }

        private void SeedTeamData()
        {
            string filePath = "../../../Data/SeedFile.json";
            var teamData = Utilities.RetrieveData<List<Team>>(filePath);
            if (teamData != null) {
                Teams = teamData.Select(s => SeedTeam(s.Seed!, s.Name!)).ToList();
            }

        }
        private void SetWinners()
        {
            string filePath = "../../../Data/AdvanceEvents.json";
            var AdvanceEventsData = Utilities.RetrieveData<AdvanceEvents>(filePath);
            if (AdvanceEventsData != null) { 
                Winners = AdvanceEventsData?.Events?.ToList();
            }
        }
    }
}
