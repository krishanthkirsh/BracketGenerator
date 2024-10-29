using BracketGenerator.Models;

namespace BracketGenerator.Interfaces
{
    public interface ISingleEliminationService
    {
        List<List<Team>> CreateGroup(List<Team> teams);
        Team SingaleMatchWithPredefinedWinner(Match match, List<string> winningTeam);
        void SetWinningTeam(Match match, Team team, List<string> winningTeam);
        Team SingaleMatch(Match match);
    }
}
