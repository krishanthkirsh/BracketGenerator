namespace BracketGenerator.Models
{
    public class TournamentInfo
    {
        public string? TournamentName { get; set; }
        public List<Team>? Teams { get; set; } = new List<Team>();
        public List<string> Winners { get; set; } = new List<string>();
        public int? GroupSize { get; set; }
    }
}
