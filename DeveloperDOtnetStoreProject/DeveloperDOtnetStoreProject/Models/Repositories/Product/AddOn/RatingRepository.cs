using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn
{
    public class RatingRepository : IGenericProductRepository<RatingModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RatingModel Find(int? id)
        {
            return db.Rating.Find(id);
        }

        public List<RatingModel> GetAll()
        {
            return db.Rating.ToList();
        }

        public void InsertOrUpdate(RatingModel entity)
        {
            if(entity.Id <= 0)
            {
                db.Rating.Add(entity);
            }
            else
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}