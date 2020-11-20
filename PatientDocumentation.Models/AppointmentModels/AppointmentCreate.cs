using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.AppointmentModels
{
    public class AppointmentCreate
    {
        [Required]
        [Display(Name = "Appointment Time")]
        public DateTimeOffset ScheduledStart { get; set; }
        [Required]
        [Display(Name = "Length")]
        public int Length { get; set; }
        [Required]
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Provider Id")]
        public int ProviderId { get; set; }
    }
}
