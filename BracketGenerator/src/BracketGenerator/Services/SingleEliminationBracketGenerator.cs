using BracketGenerator.Interfaces;
using BracketGenerator.Models;

namespace BracketGenerator.Services
{
    public class SingleEliminationBracketGenerator : IBracketGenerator
    {
        private readonly ISeedData _seedData;
        private readonly ISingleEliminationService _singleEliminationService;

        public List<Team> Teams { get; set; }
        public List<string> Winners { get; set; }
        public List<Match> TeamBracket { get; set; }
        public SingleEliminationBracketGenerator(ISeedData seedData, ISingleEliminationService singleEliminationService)
        {
            Teams = new List<Team>();
            Winners = new List<string>();
            TeamBracket = new List<Match>();
            _seedData = seedData;
            _singleEliminationService = singleEliminationService;
        }
        public List<Match> CreateTournamentBracket() 
        {
            this.InitializeTournamentData();
            int round = 0;
            while (Teams.Count > 1)
            {
                round++;
                Console.WriteLine($"------------------------Round Number {round} Team Count {Teams.Count}---------------------------");
                List<Team> teamBrackets = GenerateBracketRound();
                Teams.Clear();
                Teams = teamBrackets;
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
                var winningMatches = TeamBracket.Where(x => x.Winner?.Name == tournamentWinner?.Name).Select(s => s).ToList();
                Console.WriteLine($"----------Path To Victory----------");
                foreach (var match in winningMatches)
                {
                    pathToVictory.Add($"Winner is {match?.Winner?.Name} => {match?.TeamA?.Name} Vs {match?.TeamB?.Name}");
                    Console.WriteLine($"Winner is {match?.Winner?.Name} => {match?.TeamA?.Name} Vs {match?.TeamB?.Name}");
                }
            }

            return pathToVictory;
        }

        private List<Team> GenerateBracketRound()
        {
            List<Team> advancingTeams = new();
            var pairedTeams = _singleEliminationService.CreateGroup(Teams);

            foreach (var eachPair in pairedTeams)
            {
                var match = new Match()
                {
                    TeamA = eachPair[0],
                    TeamB = eachPair[1],
                };
                var winner = _singleEliminationService.SingaleMatchWithPredefinedWinner(match, Winners);

                advancingTeams.Add(winner);
                TeamBracket.Add(match);

                Console.WriteLine($"{match.TeamA.Name} vs {match.TeamB.Name} - Winner: {winner.Name}");
                Console.WriteLine();
            }

            return advancingTeams;
        }
        private void InitializeTournamentData()
        {
            var tournamentInfo = _seedData.GetSingleEliminationTournamentInfo();
            Teams = tournamentInfo.Teams ?? new List<Team>();
            Winners = tournamentInfo.Winners ?? new List<string>();
        }
    }
}
