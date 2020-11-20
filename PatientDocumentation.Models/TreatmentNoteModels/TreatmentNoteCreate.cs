using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.TreatmentNoteModels
{
    public class TreatmentNoteCreate
    {
        [Required]
        [Display(Name = "Treatment Start")]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        [Display(Name = "Treatment End")]
        public DateTimeOffset EndTime { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Appointment Id")]
        public int AppointmentId { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
    }
}
