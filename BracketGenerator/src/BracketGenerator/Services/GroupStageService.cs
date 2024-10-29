using BracketGenerator.Interfaces;
using BracketGenerator.Models;

namespace BracketGenerator.Services
{
    public class GroupStageService: IGroupStageService
    {
        public List<List<Team>> CreateGroupStage(List<Team> teams, int groupSize = 4)
        {
            var pairTeamsWithGrpsiz = teams.Select((team, index) => new { team, index })
                .GroupBy(x => x.index / groupSize)
                .ToList();
            var allTeamWithGroup = pairTeamsWithGrpsiz.Select(s => s.Select(x => x.team).ToList()).ToList();
            return allTeamWithGroup;
        }

        public (List<Team>, List<Match>) GroupMatch(List<Team> group)
        {
            List<Match> roundsMatch = new();
            List<Team> winningTeams = new();
            for (int i = 0; i < group.Count / 2; i++)
            {
                var match = new Match
                {
                    TeamA = group[i * 2],
                    TeamB = group[i * 2 + 1]
                };
                var winner = this.SingaleMatch(match);
                roundsMatch.Add(match);
                match.AdvaceTeam(winner);
                winningTeams.Add(winner);

            }
            return (winningTeams, roundsMatch);
        }

        public Team SingaleMatch(Match match)
        {
            if (match.TeamA == null || match.TeamB == null)
                return new Team();

            Random random = new();
            return random.Next(2) == 0 ? match.TeamA : match.TeamB;
        }
    }
}
