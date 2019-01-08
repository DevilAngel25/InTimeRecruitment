namespace InTimeRecruitment.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Configuration;
    using System.Web.Configuration;
    using System;
    using System.Diagnostics;
    using System.Web;
    internal sealed class Configuration : DbMigrationsConfiguration<InTimeRecruitment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InTimeRecruitment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            string adminEmail = ConfigurationManager.AppSettings["AdminEmail"];
            string adminPassword = ConfigurationManager.AppSettings["AdminPassword"];

            if (adminEmail != null && adminPassword != null || adminEmail != "" && adminPassword != "")
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                // Create Roles
                List<string> roleNames = new List<string>() { "Admin", "Client", "Candidate" };
                IdentityResult roleResult;
                
                // Check to see if Role Exists, if not create it
                foreach (string rn in roleNames)
                {
                    if (!RoleManager.RoleExists(rn))
                    {
                        roleResult = RoleManager.Create(new IdentityRole(rn));
                    }
                }

                if (UserManager.FindByEmail(adminEmail) == null)
                {
                    var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                    var result = UserManager.Create(user, adminPassword);

                    if (result.Succeeded)
                    {
                        var addToRole = UserManager.AddToRole(user.Id, "Admin");
                    }
                }
            }
        }
    }
}
