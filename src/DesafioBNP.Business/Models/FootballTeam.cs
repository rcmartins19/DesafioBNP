namespace DesafioBNP.Business.Models
{
    public class FootballTeam : Entity
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public int FoundationYear { get; set; }
        public bool Active { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}