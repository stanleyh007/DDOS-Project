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

    internal sealed class Configuration : DbMigrationsConfiguration<DeveloperDOtnetStoreProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DeveloperDOtnetStoreProject.Models.ApplicationDbContext";
        }

        protected override void Seed(DeveloperDOtnetStoreProject.Models.ApplicationDbContext context)
        {
            // Adding data to the CategoryHeaderModel table
            context.UserModels.AddOrUpdate(u => u.Id, new UserModel[] 
            {
                 new UserModel
               { FirstName = "Taeyeon", LastName = "Kim",  Address = "Studesgaardsgade", PostalCode = "2100", City = "Copenhagen", Email = "kimtaeyeon@sm.kr", Password = "1024Krystal,"},
            });

            context.SaveChanges();

           

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
