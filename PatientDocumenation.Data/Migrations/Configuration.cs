namespace PatientDocumenation.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PatientDocumentation.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientDocumentation.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PatientDocumentation.Data.ApplicationDbContext";
        }

        protected override void Seed(PatientDocumentation.Data.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            context.Roles.AddOrUpdate(x => x.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Provider" },
                new IdentityRole { Name = "Receptionist" },
                new IdentityRole { Name = "Patient" },
                new IdentityRole { Name = "Member"}
                );
            //checks to see if this user exists
            if (!context.Users.Any(testc=>testc.UserName == "Admin@mvc.com"))
            {
                //creates user with email/username and password
                var user = new ApplicationUser { UserName = "Admin@mvc.com", Email = "Admin@mvc.com", FirstName = "Admin" };
                userManager.Create(user, "Pw123!");

                //Adds the Admin role to the user we just created.
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
