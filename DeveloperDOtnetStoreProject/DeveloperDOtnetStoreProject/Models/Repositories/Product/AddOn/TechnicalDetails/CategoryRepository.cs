using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn.TechnicalDetails
{
    public class CategoryRepository : IGenericProductRepository<CategoryModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            else
            {
                CategoryModel item = Find(id);
                db.Category.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public CategoryModel Find(int? id)
        {
            return db.Category.Find(id);
        }

        public List<CategoryModel> GetAll()
        {
            return db.Category.ToList();
        }

        public void InsertOrUpdate(CategoryModel entity)
        {
            if (entity.CategoryModelId <= 0)
            {
                db.Category.Add(entity);
            }
            else
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}