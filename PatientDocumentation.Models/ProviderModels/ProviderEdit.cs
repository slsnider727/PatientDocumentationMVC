using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumentation.Models.ProviderModels
{
    public class ProviderEdit
    {
        [Display(Name = "Provider Id")]
        public int ProviderId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string License { get; set; }
        public string Specialization { get; set; }
        [Display(Name = "Clinic Id")]
        public int ClinicId { get; set; }
        public string UserId { get; set; }
        // for uploading a new file
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Image { get; set; }
        // for displaying the current image
        public byte[] ImageAsBytes { get; set; }//This is like a backing field.
        public string ImageFile { get; set; }
    }
}
