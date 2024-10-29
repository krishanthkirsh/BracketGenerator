using BracketGenerator.Helper;
using BracketGenerator.Interfaces;

namespace BracketGenerator.Services
{
    public class TournamentGenerator : ITournamentGenerator
    {
        private readonly IBracketTournamentFactory _bracketTournamentFactory;

        public TournamentGenerator(IBracketTournamentFactory bracketTournamentFactory)
        {
            this._bracketTournamentFactory = bracketTournamentFactory;
        }
        public void RunAsyn()
        {
            Console.WriteLine("Welcome to the  2022 soccer world cup Bracket Generator!");
            bool isGroupElimination = Utilities.GetUserChoice("Do you want to start group stage ? (Y = Yes, N = No) ");
            Console.WriteLine();

            IBracketGenerator bracketGenerator;

            if (isGroupElimination)
            {
                bracketGenerator = _bracketTournamentFactory.CreateBracketTournament("GroupStageBracket");
            }
            else {
                bracketGenerator = _bracketTournamentFactory.CreateBracketTournament("SingleEliminationBracket");
            }

            bracketGenerator.CreateTournamentBracket();
            bracketGenerator.GetTournamentWinner();
            bracketGenerator.PathToVictory();
        }
    }
}
