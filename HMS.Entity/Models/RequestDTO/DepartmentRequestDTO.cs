using System.ComponentModel.DataAnnotations;

namespace HMS.Entity.Models.RequestDTO
{
    public class DepartmentRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
