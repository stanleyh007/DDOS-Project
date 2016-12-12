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
 
