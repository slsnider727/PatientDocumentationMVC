using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.TreatmentNoteModels
{
    public class TreatmentNoteListItem
    {
        [Display(Name = "Note Id")]
        public int TreatmentNoteId { get; set; }
        [Display(Name = "Patient")]
        public string PatientName { get; set; }
        [Display(Name = "Provider")]
        public string ProviderName { get; set; }
        [Display(Name = "Appointment Date")]
        public DateTimeOffset AppointmentDate { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
