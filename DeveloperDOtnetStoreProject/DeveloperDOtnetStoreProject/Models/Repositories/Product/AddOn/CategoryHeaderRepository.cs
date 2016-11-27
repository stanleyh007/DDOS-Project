using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn
{
    public class CategoryHeaderRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Crud To the database
        // Find a single CategoryHeaderModel
        public CategoryHeaderModel Find(int? id)
        {
            return db.CategoryHeader.Find(id);
        }
        // Get all categoryHeaderModels
        public List<CategoryHeaderModel> GetAll()
        {
            return db.CategoryHeader.ToList();
        }

        // Insert or update Category
        public void InsertOrUpdate(CategoryHeaderModel categoryHeader)
        {
            if(categoryHeader.CategoryHeaderModelId <= 0)
            {
                db.CategoryHeader.Add(categoryHeader);
            }
            else
            {
                db.Entry(categoryHeader).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
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
                db.CategoryHeader.Remove(cHeader);
                db.SaveChanges();
                return true;
            }
        }
    }
}