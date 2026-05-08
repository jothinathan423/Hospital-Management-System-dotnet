namespace HMS.Entity.Models.ResponseDTO
{
    public class PatientResponseDTO
    {
        public int PatientId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;
    }
}
