using System.ComponentModel.DataAnnotations;

namespace HMS.Entity.Models.RequestDTO
{
    public class DoctorRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;

        [Range(0, 60)]
        public int Experience { get; set; }

        [Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }
    }
}
