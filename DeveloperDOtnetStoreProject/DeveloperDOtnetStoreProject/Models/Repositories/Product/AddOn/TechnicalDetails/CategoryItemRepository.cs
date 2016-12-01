using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn.TechnicalDetails
{
    public class CategoryItemRepository : IGenericProductRepository<CategoryItemModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationDbContext GetDB()
        {
            return db;
        }

        public CategoryItemModel Find(int? id)
        {
            return db.CategoryItem.Find(id);
        }

        public List<CategoryItemModel> GetAll()
        {
            return db.CategoryItem.ToList();
        }

        public void InsertOrUpdate(CategoryItemModel categoryItem)
        {
            if(categoryItem.Id <= 0)
            {
                db.CategoryItem.Add(categoryItem);
            }
            else
            {
                db.Entry(categoryItem).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

        public bool Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            else
            {
                db.CategoryItem.Remove(db.CategoryItem.Find(id));
                db.SaveChanges();
                return true;
            }
        }
    }
}