using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumentation.Models.ProviderModels
{
    public class ProviderCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Title { get; set; }
        [Required]
        [Display(Name = "License #")]
        public string License { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        [Display(Name = "Clinic Id")]
        public int ClinicId { get; set; }
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageFile { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }
    }
}
