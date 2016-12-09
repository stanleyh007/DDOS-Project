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

        protected override void Seed(DeveloperDOtnetStoreProject.Models.ApplicationDbContext context)
        {
            // Adding data to the CategoryHeaderModel table
            /*ProductDatabaseConfiguration cPD = new ProductDatabaseConfiguration();
            context = cPD.getProductDatabaseUpdate(context);*/

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));
            rm.Create(new IdentityRole("Kunde"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // admin
            var client2 = new ApplicationUser { UserName = "a@b.c" };
            var result1 = userManager.Create(client2, "P_assw0rd1");

            // Kunde
            var costumerClient = new ApplicationUser { UserName = "kunde@kunde.dk" };
            var result2 = userManager.Create(client2, "P_assw0rd1");

            if (result1.Succeeded == false)
            {
                client2 = userManager.FindByName("a@b.c");
            }

            if (result2.Succeeded == false)
            {
                costumerClient = userManager.FindByName("kunde@kunde.dk");
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
