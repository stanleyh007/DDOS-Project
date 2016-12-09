using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn
{
    public class CostumerReviewRepository : IGenericProductRepository<CostumerReviewModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            else
            {
                CostumerReviewModel item = Find(id);
                db.CostumerReview.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public CostumerReviewModel Find(int? id)
        {
            return db.CostumerReview.Find(id);
        }

        public List<CostumerReviewModel> GetAll()
        {
            return db.CostumerReview.ToList();
        }

        public void InsertOrUpdate(CostumerReviewModel entity)
        {
            if(entity.CostumerReviewModelId <= 0)
            {
                db.CostumerReview.Add(entity);
            }
            else
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}