using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.TreatmentNoteModels
{
    public class TreatmentNoteEdit
    {
        [Display(Name = "Note Id")]
        public int TreatmentNoteId { get; set; }
        [Display(Name = "Treatment Start")]
        public DateTimeOffset StartTime { get; set; }
        [Display(Name = "Treatment End")]
        public DateTimeOffset EndTime { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
