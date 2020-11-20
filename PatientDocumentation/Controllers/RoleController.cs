using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientDocumentation.Data;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            //var model = context.Users.ToList();

            var service = new UserService();
            var users = service.GetUsers();
            //foreach (ApplicationUser user in model)
            //{
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            //ViewBag.RolesForThisUser = userManager.GetRoles(user.Id).ToList();
            //}

            return View(users);
        }

        // GET: Add Role to User
        public ActionResult Add(string userName)
        {
            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //ViewBag.UserName = userName;

            //Drop-Down List
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            return View();
        }

        //POST: Add Role to User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string UserName, string RoleName)
        {
            var context = new ApplicationDbContext();

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(user.Id, RoleName);

            TempData["SaveResult"] = "Role added successfully.";
            return RedirectToAction("Index");
        }

        // GET: Remove Role From User
        public ActionResult Remove(string userName)
        {
            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            //Drop-Down List
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            return View();
        }

        //POST: Remove Role From User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(string UserName, string RoleName)
        {
            var account = new AccountController();
            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (userManager.IsInRole(user.Id, RoleName))
            {
                userManager.RemoveFromRole(user.Id, RoleName);
                TempData["SaveResult"] = "Role removed successfully.";
                return RedirectToAction("Index");
            }
            else //This throws an error instead of populating error message.
            {
                TempData["SaveResult"] = "This user doesn't belong to selected role.";
                return View();
            }
        }

    }
}