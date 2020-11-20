using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Models
{
    public class UserListItem
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Roles")]
        public List<string> RolesList { get; set; }
    }
}
