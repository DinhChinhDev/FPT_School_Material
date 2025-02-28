using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set;}
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }

    }
}
