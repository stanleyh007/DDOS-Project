namespace DeveloperDOtnetStoreProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Product.AddOn;
    using Models.User;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DeveloperDOtnetStoreProject.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Adding data to User
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    context));

            for (int i = 0; i < 4; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("User{0}", i.ToString()),

                    //Add following seed data
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString()),
                    Address = string.Format("Address{0}", i.ToString()),
                    PostalCode = string.Format("PostalCode{0}", i.ToString()),
                    City = string.Format("City{0}", i.ToString()),
                    
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }

            //Adding data to Role
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            role.Create(new IdentityRole("Administrator"));
            role.Create(new IdentityRole("Kunde"));

            

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
        }
    }
}
