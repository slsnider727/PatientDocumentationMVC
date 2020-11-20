using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.AppointmentModels
{
    public class AppointmentDetail
    {
        public int AppointmentId { get; set; }
        [Display(Name = "Appointment Time")]
        public DateTimeOffset ScheduledStart { get; set; }
        [Display(Name = "Length")]
        public int Length { get; set; }
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Scheduled By")]
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified By")]
        public Guid? ModifiedBy { get; set; }
        public int PatientId { get; set; }
        public string Patient { get; set; }
        public int ProviderId { get; set; }
        public string Provider { get; set; }
    }
}
