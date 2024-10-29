namespace BracketGenerator.Models
{
    public class Match
    {
        public Team? TeamA { get; set; }
        public Team? TeamB { get; set; }
        public Team? Winner { get; set; }

        public void AdvaceTeam(Team winnerTeam)
        {
            Winner = winnerTeam;
        }
    }
}
