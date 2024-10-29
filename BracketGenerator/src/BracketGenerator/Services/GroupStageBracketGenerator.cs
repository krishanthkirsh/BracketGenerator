using BracketGenerator.Interfaces;
using BracketGenerator.Models;

namespace BracketGenerator.Services
{
    public class GroupStageBracketGenerator : IBracketGenerator
    {
        private readonly ISeedData _seedData;
        private readonly IGroupStageService _groupStageService;
        public List<Team> Teams { get; set; }
        public List<Match> TeamBracket { get; set; }
        public int? GroupSize { get; set; }

        public GroupStageBracketGenerator(ISeedData seedData, IGroupStageService groupStageService)
        {
            _seedData = seedData;
            TeamBracket = new List<Match>();
            Teams = new List<Team>();
            _groupStageService = groupStageService;
        }
        public List<Match> CreateTournamentBracket()
        {
            this.InitializeGroupTournamentData();
            int round = 0;
            while (Teams.Count > 1)
            {
                List<Team> winningTeams = new();
                if (Teams.Count >= GroupSize)
                {
                    round++;
                    var allGroups = _groupStageService.CreateGroupStage(Teams, (int)GroupSize);
                    Console.WriteLine($"----------Round: {round}----------Teams Count: {allGroups.Count * GroupSize}----------Group Count: {allGroups.Count}----------");
                    Console.WriteLine();

                    int groupNumber = 0;
                    foreach (var group in allGroups)
                    {
                        groupNumber++;
                        var (groupWinners, groupMatches) = _groupStageService.GroupMatch(group);
                        winningTeams.AddRange(groupWinners);
                        TeamBracket.AddRange(groupMatches);
                        DisplayGroupDetails(group, groupMatches, groupNumber.ToString());
                    }
                    Teams = winningTeams;
                }else
                {
                    Console.WriteLine($"----------Final Round----------");
                    Console.WriteLine();

                    var (groupWinners, groupMatches) = _groupStageService.GroupMatch(Teams);
                    winningTeams.AddRange(groupWinners);
                    TeamBracket.AddRange(groupMatches);
                    DisplayGroupDetails(Teams, groupMatches, "Final Round");
                }
                Teams = winningTeams.Count == 1 ? winningTeams : new List<Team>();
            }
            return TeamBracket;
        }

        public Team? GetTournamentWinner()
        {
            var winner = TeamBracket.Last().Winner;
            Console.WriteLine($"----------winner: {winner?.Name}----------");
            return winner;
        }

        public List<string> PathToVictory()
        {
            List<string> pathToVictory = new();

            if (TeamBracket.Any())
            {
                var tournamentWinner = TeamBracket.LastOrDefault()?.Winner;
                var winningMatches = TeamBracket.Where(x => x.Winner?.Name == tournamentWinner?.Name).Select(s  => s).ToList();
                Console.WriteLine($"----------Path To Victory----------");
                foreach (var match in winningMatches)
                {
                    pathToVictory.Add($"Winner is {match.Winner} => {match?.TeamA?.Name} Vs {match?.TeamB?.Name}");
                    Console.WriteLine($"Winner is {match?.Winner?.Name} => {match?.TeamA?.Name} Vs {match?.TeamB?.Name}");
                }
            }

            return pathToVictory;
        }

        private void InitializeGroupTournamentData()
        {
            var tournamentInfo = _seedData.GetGroupStageTournamentInfo();
            Teams = tournamentInfo.Teams ?? new List<Team>();
            GroupSize = tournamentInfo.GroupSize;
        }
        private static void DisplayGroupDetails(List<Team> group, List<Match> groupMatches, string groupNumber)
        {
            Console.WriteLine($"----------Group Number: {groupNumber}----------");
            foreach (var team in group)
            {
                Console.WriteLine(team.Name);
            }
            Console.WriteLine();
            foreach (var match in groupMatches)
            {
                Console.WriteLine($"{match.TeamA?.Name}----------VS: {match.TeamB?.Name}----------Winner: {match.Winner?.Name}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
