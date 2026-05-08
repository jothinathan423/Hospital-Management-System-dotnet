namespace HMS.Entity.Models.ResponseDTO
{
    public class DoctorResponseDTO
    {
        public int DoctorId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public int Experience { get; set; }

        public int DepartmentId { get; set; }
    }
}
