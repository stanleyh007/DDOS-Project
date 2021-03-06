﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Interfaces;
using System.Diagnostics;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Find specific Product
        public ProductModel Find(int? id)
        {
            return db.Products.Find(id);   
        }
        // GetAll()
        public List<ProductModel> GetAll()
        {
            return db.Products.ToList();
        }
        
        // ADD or Update
        public void InsertOrUpdate(ProductModel product)
        {
            if(product == null)
            {
                
            }
            else if(product.ProductModelId <= 0)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            else
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
        }

        // Delete Product
        public bool Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            else
            {
                ProductModel product = Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
        }

        public List<ProductModel> SearchProducts(string productSearch)
        {
            IEnumerable<ProductModel> products = GetAll();


            if (!String.IsNullOrEmpty(productSearch))
            {
                // Linq 101 HC's way
                //products = products.Where();

                // Linq 101 HC's way
                products = products.Where(p =>
                                          p.NameHeader.ToLower().Contains(productSearch.ToLower()) ||
                                          p.NameDescription.ToLower().Contains(productSearch.ToLower()) ||
                                          p.Price.ToString().Contains(productSearch) ||
                                          p.ProductModelId.ToString().Contains(productSearch)
                );
                /*
                // Linq Kirschbergs way
                var pSearched = from p in products
                                where   p.NameHeader.ToLower().Contains(productSearch.ToLower()) ||
                                        p.NameDescription.ToLower().Contains(productSearch.ToLower())

                                select p;
                products = pSearched.ToList();
                */
            }
            return products.ToList();
        }
        /*
        //Christian Kirschberg Try the following: Go to Menu: View ->
                Other Windows ->
        Package Manager Console :

        Write in console :
        enable-migrations -enableautomaticmigrations

        After that, we do this : update-database -force
        (-force will force the schema change to the database even if data is lost)

        If that gives you an error, try:

        Delete migrations folder of the project.

        Delete the database files located in your App_Data folder.

        Write the following commands in the package manager console:
        sqllocaldb.exe stop v11.0
        sqllocaldb.exe delete v11.0

        enable-migrations -enableautomaticmigrations (add -force if needed)

        update-database(add -force if needed)
        */
        /*
         * Troels Helbo Jensen
         * If the ApplicationDbContext methode  can't find your tables
         * 1: go IdentityModels.cs -> Look at line 35
         * 1.1: Add Line for new Table link between ApplicationDbContext to the databae
         */
    }
}