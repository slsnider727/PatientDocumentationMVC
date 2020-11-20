using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumenation.Data
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [Required]
        public string Name { get; set; }
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
        public byte[] Image { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}
