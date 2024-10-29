using BracketGenerator.Models;

namespace BracketGenerator.Interfaces
{
    public interface ISeedData
    {
        TournamentInfo GetSingleEliminationTournamentInfo();
        TournamentInfo GetGroupStageTournamentInfo();
    }
}
