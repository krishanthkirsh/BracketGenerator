namespace BracketGenerator.Interfaces
{
    public interface IBracketTournamentFactory
    {
        IBracketGenerator CreateBracketTournament(string type);
    }
}
