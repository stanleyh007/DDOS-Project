namespace DeveloperDOtnetStoreProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Product.AddOn;
    using Models.Product.AddOn.TechnicalDetails;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            context.CategoryHeader.AddOrUpdate(ch => ch.Name, new CategoryHeaderModel[] 
            {
                new CategoryHeaderModel
                {
                    Name = "Grafikkort"
                },
                new CategoryHeaderModel
                {
                    Name = "Harddisk"
                },
                new CategoryHeaderModel
                {
                    Name = "Bundkort"
                }
            });

            // Adding item to the Category Header
            /*context.CategoryItem.AddOrUpdate(ci => ci.ItemName, new CategoryItemModel[]
            {
                // This is the items to fil out the Generel -> ProductType -> [items]
                new CategoryItemModel
                {
                    HeaderName = "Enhedstype",
                    ItemName = "Grafikkort",
                    isItemNameUSed = false
                },
                new CategoryItemModel
                {
                    HeaderName = "Interfacer",
                    ItemName = null,
                    isItemNameUSed = true,
                    ItemNames = {"DVI-D", "2xDisplayPort", "2xHDMI"}
                }
            });*/

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var client2 = new ApplicationUser { UserName = "a@b.c" };
            var result1 = userManager.Create(client2, "P_assw0rd1");

            if(result1.Succeeded == false)
            {
                client2 = userManager.FindByName("a@b.c");
            }

            context.SaveChanges();

            userManager.AddToRole(client2.Id, "admin");

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
