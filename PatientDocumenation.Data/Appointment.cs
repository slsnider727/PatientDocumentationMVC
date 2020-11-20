using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumenation.Data
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        [Display(Name = "Appointment Time")]
        public DateTimeOffset ScheduledStart { get; set; }
        [Required]
        [Display(Name = "Length")]
        public int Length { get; set; } //minutes
        [Display(Name = "Appointment End")]
        public DateTimeOffset ScheduledEnd
        {
            get
            {
                return ScheduledStart.AddMinutes(Length);
            }
        }
        [Required]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Scheduled By")]
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified By")]
        public Guid? ModifiedBy { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Required]
        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
