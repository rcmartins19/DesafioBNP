namespace DesafioBNP.Business.Models
{
    public class Player : Entity
    {

        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }
        public bool Active { get; set; }

        public FootballTeam FootballTeam { get; set; }
    }
}