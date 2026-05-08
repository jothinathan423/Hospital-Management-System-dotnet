using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
    }
}
