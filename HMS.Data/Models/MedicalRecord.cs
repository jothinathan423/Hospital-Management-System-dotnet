using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Data.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        public string Allergies { get; set; } = string.Empty;
        public string PreviousDiseases { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
