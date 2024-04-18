using System.ComponentModel.DataAnnotations;

namespace DesafioBNP.Api.Dtos
{
    public class PlayerDto
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(15, 80, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(1, 99, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int ShirtNumber { get; set; }

        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public string TeamName { get; set; }
    }
}