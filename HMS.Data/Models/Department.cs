using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
