using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Interfaces;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn
{
    public class CategoryHeaderRepository : IGenericProductRepository<CategoryHeaderModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Crud To the database
        // Find a single CategoryHeaderModel
        public CategoryHeaderModel Find(int? id)
        {
            return db.CategoryHeaderModels.Find(id);
        }
        // Get all categoryHeaderModels
        public List<CategoryHeaderModel> GetAll()
        {
            try { 
                return db.CategoryHeaderModels.ToList();
            } catch(Exception e)
            {
                return new List<CategoryHeaderModel>();
            }
        }

        // Insert or update Category
        public bool InsertOrUpdate(CategoryHeaderModel categoryHeader)
        {
            try
            {
                if (categoryHeader.CategoryHeaderModelId <= 0)
                {
                    db.CategoryHeaderModels.Add(categoryHeader);
                }
                else
                {
                    db.Entry(categoryHeader).State = System.Data.Entity.EntityState.Modified;
                }
            
                db.SaveChanges();
                return true;
            } catch(SqlException eSQL)
            {
                Debug.WriteLine("CategoryHeaderRepository file Execption\n" + eSQL);
                return false;
            }
        }

        // Delete some categoryHeader
        public bool Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            else
            {
                CategoryHeaderModel cHeader = Find(id);
                db.CategoryHeaderModels.Remove(cHeader);
                db.SaveChanges();
                return true;
            }
        }
    }
}