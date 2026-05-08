using System.ComponentModel.DataAnnotations;

namespace HMS.Entity.Models.RequestDTO
{
    public class PatientRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(10)]
        public string BloodGroup { get; set; } = string.Empty;
    }
}
