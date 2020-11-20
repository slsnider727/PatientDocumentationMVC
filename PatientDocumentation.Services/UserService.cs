using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientDocumentation.Data;
using PatientDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class UserService
    {
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(ctx);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var users = ctx.Users.ToList();
                var results = new List<UserListItem>();
                foreach (var user in users)
                {
                    var roles = userManager.GetRoles(user.Id).ToList();
                    UserListItem item = new UserListItem()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        RolesList = roles
                    };
                    results.Add(item);
                }
                return results;
            }
        }

    }
}
