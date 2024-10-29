using BracketGenerator.Interfaces;

namespace BracketGenerator.Services
{
    public class BracketTournamentFactory : IBracketTournamentFactory
    {
        private readonly ISeedData _seedData;
        private readonly IGroupStageService _groupStageService;
        private readonly ISingleEliminationService _singleEliminationService;

        public BracketTournamentFactory(ISeedData seedData, IGroupStageService groupStageService, ISingleEliminationService singleEliminationService)
        {
            this._seedData = seedData;
            _groupStageService = groupStageService;
            _singleEliminationService = singleEliminationService;
        }
        public IBracketGenerator CreateBracketTournament(string type)
        {

            switch (type)
            {
                case "SingleEliminationBracket":
                    return new SingleEliminationBracketGenerator(_seedData, _singleEliminationService);
                case "GroupStageBracket":
                    return new GroupStageBracketGenerator(_seedData, _groupStageService);
                default:
                    throw new NotSupportedException($"Bracket generator type '{type}' is not supported.");
            }
        }
    }
}
