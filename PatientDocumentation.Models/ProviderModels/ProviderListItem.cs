using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumentation.Models.ProviderModels
{
    public class ProviderListItem
    {
        [Display(Name = "Provider Id")]
        public int ProviderId { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string Clinic { get; set; }
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
