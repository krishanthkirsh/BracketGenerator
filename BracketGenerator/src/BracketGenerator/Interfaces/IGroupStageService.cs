using BracketGenerator.Models;

namespace BracketGenerator.Interfaces
{
    public interface IGroupStageService
    {
        List<List<Team>> CreateGroupStage(List<Team> teams, int groupSize);
        (List<Team>, List<Match>) GroupMatch(List<Team> group);
        Team SingaleMatch(Match match);
    }
}
