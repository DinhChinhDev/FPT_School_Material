using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBusiness
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set;} = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public bool Gender { get; set; } = false;
        public string? Address { get; set; } = string.Empty;
    }
}
