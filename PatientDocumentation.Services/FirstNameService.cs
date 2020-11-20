using PatientDocumentation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class FirstNameService
    {
        public static string GetUserFirstName(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.Id == id);
                return entity.FirstName;
            };
        }
    }
}
    
