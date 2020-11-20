using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumenation.Data
{
    public class TreatmentNote
    {
        [Key]
        public int TreatmentNoteId { get; set; }
        [Required]
        [Display(Name = "Written By")]
        public Guid AuthorId { get; set; }
        [Required]
        [Display(Name = "Treatment Start")]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        [Display(Name = "Treatment End")]
        public DateTimeOffset EndTime { get; set; }
        [Display(Name = "Total Treat Time")]
        public int TotalTreatTime
        {
            get
            {
                TimeSpan treatment = EndTime - StartTime;
                return Convert.ToInt32(Math.Floor(treatment.TotalMinutes));
            }
        }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public int PatientId { get; set; }

    }
}
