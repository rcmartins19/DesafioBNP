using System.ComponentModel.DataAnnotations;

namespace DesafioBNP.Api.Dtos
{
    public class FootballTeamDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 3)]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(1900, 2024, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int FoundationYear { get; set; }

        public bool Active { get; set; }
        
        public IEnumerable<PlayerDto?> Players { get; set; }
    }
}
