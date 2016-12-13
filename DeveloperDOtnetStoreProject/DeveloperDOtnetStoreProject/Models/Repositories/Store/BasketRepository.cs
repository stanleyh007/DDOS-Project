using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Store
{
    public class BasketRepository : IBasketRepository<BasketModel>
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
                BasketModel product = Find(id);
                db.baskets.Remove(product);
                db.SaveChanges();
                return true;
            }
        }

        public List<BasketProductModel> GetAllProducts()
        {
            return db.basketProducts.ToList();
        }

        public List<BasketModel> GetAll()
        {
            return db.baskets.ToList();
        }

        public BasketModel Find(int? id)
        {
            return db.baskets.Find(id);
        }

        public bool InsertOrUpdate(BasketModel basket)
        {
            if (basket.Id <= 0)
            {
                db.baskets.Add(basket);
            }
            else
            {
                db.Entry(basket).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return true;
        }
    }
}