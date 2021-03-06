namespace DeveloperDOtnetStoreProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Security;

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
            var client2 = new ApplicationUser { UserName = "a@b.c", FirstName = "Troels", LastName = "Jensen", Address = "addressssssssss", PostalCode = "2650", City = "Hvidovre" };
            var result1 = manager.Create(client2, "P_assw0rd1");
            var adminrole = manager.AddToRole(client2.Id, "Administrator");

            // Kunde
            var costumerClient = new ApplicationUser { UserName = "kunde@kunde.dk", FirstName = "Xinkai", LastName = "Huang", Address = "addressssssssssss", PostalCode = "2100", City = "K�benhavn �" };
            var result2 = manager.Create(costumerClient, "P_assw0rd1");
            var costumerrole = manager.AddToRole(costumerClient.Id, "Kunde");

            if (result1.Succeeded == false)
            {
                client2 = manager.FindByName("a@b.c");
            }

                if (result2.Succeeded == false)
                {
                    costumerClient = manager.FindByName("kunde@kunde.dk");
                }

                ProductDatabaseConfiguration context1 = new ProductDatabaseConfiguration();
                context = context1.getProductDatabaseUpdate(context);

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

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException eDbEV)
                    {
                        foreach (var validationErrors in eDbEV.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}",
                                                        validationError.PropertyName,
                                                        validationError.ErrorMessage);
                            }
                        }
                    }   

                }
            }
        }
 
