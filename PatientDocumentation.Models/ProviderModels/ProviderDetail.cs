using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumentation.Models.ProviderModels
{
    public class ProviderDetail
    {
        [Display(Name = "Provider Id")]
        public int ProviderId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "License #")]
        public string License { get; set; }
        public string Specialization { get; set; }
        [Display(Name = "Clinic Id")]
        public int ClinicId { get; set; }
        public string Clinic { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicCityStateZip { get; set; }
        [Display(Name = "Contact")]
        public string ClinicPhone { get; set; }
        public string UserId { get; set; }
        public byte[] ImageAsBytes { get; set; } //This is like a backing field.
        [Display(Name = "Image")]
        public string ImageFile 
        {
            get 
            {
                if (ImageAsBytes != null)
                {
                    string mimeType = "image/jpeg"; //Get mime type somehow (e.g. "image/png")
                    string base64 = Convert.ToBase64String(ImageAsBytes);
                    return string.Format($"data:{mimeType}, base64:{base64}");
                }
                else
                    return "";
            }
        }
    }
}
