using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBusiness
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; } = DateTime.Now;
        public string? Reason { get; set; } =string.Empty;
        public int? PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public Doctor? Doctor {  get; set; } 

    }
}
