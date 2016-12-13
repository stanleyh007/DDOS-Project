namespace DeveloperDOtnetStoreProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Product;
    using Models.Product.AddOn;
    using Models.User;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeveloperDOtnetStoreProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
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
      
            // admin
            var client2 = new ApplicationUser { UserName = "a@b.c", FirstName = "Troels", LastName = "Jensen", Address = "addressssssssss", PostalCode = "2650", City = "Hvidovre"};
            var result1 = manager.Create(client2, "P_assw0rd1");

            // Kunde
            var costumerClient = new ApplicationUser { UserName = "kunde@kunde.dk", FirstName = "Xinkai", LastName = "Huang", Address = "addressssssssssss", PostalCode = "2100", City = "København Ø" };
            var result2 = manager.Create(costumerClient, "P_assw0rd1");

            if (result1.Succeeded == false)
            {
                client2 = manager.FindByName("a@b.c");
            }

            if (result2.Succeeded == false)
            {
                costumerClient = manager.FindByName("kunde@kunde.dk");
            }
            
            // Get all nye rows to database
            ProductDatabaseConfiguration getDbContext = new ProductDatabaseConfiguration();
            context = getDbContext.getProductDatabaseUpdate(context);
            //context = getProductDatabaseUpdate(context);
            try {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
