using BracketGenerator.Models;

namespace BracketGenerator.Interfaces
{
    public interface IBracketGenerator
    {
        List<Match> CreateTournamentBracket();
        Team? GetTournamentWinner();
        List<string> PathToVictory();
    }
}
