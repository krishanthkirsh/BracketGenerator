using BracketGenerator.Interfaces;
using BracketGenerator.Models;

namespace BracketGenerator.Services
{
    public class SingleEliminationService : ISingleEliminationService
    {
        public List<List<Team>> CreateGroup(List<Team> teams)
        {
            var groups = new List<List<Team>>();
            for (int i = 0; i < teams.Count / 2; i++)
            {
                groups.Add(new List<Team> { teams[2 * i], teams[2 * i + 1] });
            }
            return groups;
        }

        public Team SingaleMatchWithPredefinedWinner(Match match, List<string> winningTeam)
        {
            if (match.TeamA != null && match.TeamB != null)
            {
                if (winningTeam.Contains(match.TeamA.Name!))
                {
                    SetWinningTeam(match, match.TeamA, winningTeam);
                    return match.TeamA!;
                }
                else if (winningTeam.Contains(match.TeamB.Name!))
                {
                    SetWinningTeam(match, match.TeamB, winningTeam);
                    return match.TeamB!;
                }
                else
                {
                    var randoWinner = SingaleMatch(match);
                    SetWinningTeam(match, randoWinner, winningTeam);
                    return randoWinner;
                }
            }
            return new Team();
        }

        public void SetWinningTeam(Match match, Team team, List<string> winningTeam)
        {
            match.AdvaceTeam(team);
            winningTeam.Remove(team.Name!);
        }

        public Team SingaleMatch(Match match)
        {
            if (match.TeamA != null && match.TeamB != null)
            {
                Random random = new();
                var winningTeam = random.Next(2) == 0 ? match.TeamA : match.TeamB;
                return winningTeam;
            }
            return new Team();
        }
    }
}
