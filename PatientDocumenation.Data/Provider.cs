using Microsoft.AspNet.Identity;
using PatientDocumentation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumenation.Data
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName +", " + Title;
            }
        }
        [Required]
        [Display(Name ="License #")]
        public string License { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
