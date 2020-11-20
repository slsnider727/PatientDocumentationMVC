using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.TreatmentNoteModels
{
    public class TreatmentNoteDetail
    {
        [Display(Name = "Treatment Note Id")]
        public int TreatmentNoteId { get; set; }
        [Display(Name = "Written By")]
        public Guid AuthorId { get; set; }
        public string Patient { get; set; }
        public string Provider { get; set; }
        [Display(Name ="Treatment Start")]
        public DateTimeOffset StartTime { get; set; }
        [Display(Name = "Treatment End")]
        public DateTimeOffset EndTime { get; set; }
        [Display(Name = "Total Treat Time")]
        public int TotalTreatTime { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Appointment Id")]
        public int AppointmentId { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
    }
}
