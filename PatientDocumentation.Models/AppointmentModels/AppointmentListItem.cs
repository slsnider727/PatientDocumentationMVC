using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.AppointmentModels
{
    public class AppointmentListItem
    {
        public int AppointmentId { get; set; }
        public string Patient { get; set; }
        [Display(Name = "Appointment Time")]
        public DateTimeOffset ScheduledStart { get; set; }
        [Display(Name = "Length")]
        public int Length { get; set; }
        public string Provider { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
    }
}
