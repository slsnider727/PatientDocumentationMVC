using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.AppointmentModels
{
    public class AppointmentEdit
    {
        public int AppointmentId { get; set; }
        [Display(Name = "Appointment Time")]
        public DateTimeOffset ScheduledStart { get; set; }
        [Display(Name = "Length")]
        public int Length { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Provider Id")]
        public int ProviderId { get; set; }
    }
}
