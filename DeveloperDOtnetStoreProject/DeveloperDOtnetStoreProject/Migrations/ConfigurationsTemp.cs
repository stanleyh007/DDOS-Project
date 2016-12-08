﻿/*
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
*/  
            // Adding data to the CategoryHeaderModel table
            /*ProductDatabaseConfiguration cPD = new ProductDatabaseConfiguration();
            context = cPD.getProductDatabaseUpdate(context);*/
/*
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

            context = getProductDatabaseUpdate(context);
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

        private ApplicationDbContext getProductDatabaseUpdate(ApplicationDbContext context)
        {
            // CateGoryHeader
            context.CategoryHeaderModels.AddOrUpdate(s => s.Name, new CategoryHeaderModel[] {
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 1,
                                                   Name = "Grafikkort"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 2,
                                                   Name = "Harddisk"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 3,
                                                   Name = "Bundkort"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                   CategoryHeaderModelId = 4,
                                                   Name = "Ram"
                                               },
                                               new CategoryHeaderModel
                                               {
                                                    CategoryHeaderModelId = 5,
                                                    Name = "Lydkort"
                                               }
            });
*/
            // Products
            /* 
                public string NameHeader { get; set; }
                public string NameDescription { get; set; }
                public double Price { get; set; }
                public int QuantityStorage { get; set; }
                public int CategoryHModelId { get; set; }
             */
/*
             context.Products.AddOrUpdate(s => s.NameHeader, new ProductModel[] {
                                        new ProductModel
                                        {
                                            NameHeader = "Nvidia GFx 9000 Series",
                                            NameDescription = "Grafikkort",
                                            Price = 4599,
                                            QuantityStorage = 2,
                                            CategoryHModelId = 1
                                        },
                                        new ProductModel
                                        {
                                            NameHeader = "Kingston SuperFast Ram 2x8Gb",
                                            NameDescription = "Ram 2x8Gb 20400MHz",
                                            Price = 999,
                                            QuantityStorage = 4,
                                            CategoryHModelId = 1
                                        }
            });

            // UserModel
            context.UserModels.AddOrUpdate(u => u.Id, new UserModel[] {
                                new UserModel
                                {
                                    FirstName = "Taeyeon",
                                    LastName = "Kim",
                                    Address = "Studesgaardsgade",
                                    PostalCode = "2100",
                                    City = "Copenhagen",
                                    Email = "kimtaeyeon@sm.kr",
                                    Password = "1024Krystal,"
                                }
            });

            return context;
        }
    }
}
*/