using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models.PatientModels
{
    public class PatientEdit
    {
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Incorrect number of characters.")]
        public string State { get; set; }
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Incorrect number of digits.")]
        public string Zip { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Incorrect number of digits.")]
        public string Phone { get; set; }
    }
}
