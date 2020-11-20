using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PatientDocumenation.Data
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public  int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DOB;
                double totalAge = ageSpan.TotalDays / 365.24;
                return Convert.ToInt32(Math.Floor(totalAge));
            }
        }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Incorrect number of characters.")]
        public string State { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Incorrect number of digits.")]
        public string Zip { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Incorrect number of digits.")]
        public string Phone { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        //[ForeignKey("User")]
        //public Guid? UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
