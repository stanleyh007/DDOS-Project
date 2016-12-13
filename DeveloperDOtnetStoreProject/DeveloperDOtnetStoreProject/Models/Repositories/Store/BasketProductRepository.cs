using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Store;

namespace DeveloperDOtnetStoreProject.Models.Repositories.Store
{
    public class BasketProductRepository : IBasketRepository<BasketProductModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public BasketProductModel Find(int? id)
        {
            return db.basketProducts.Find(id);
        }

        public bool Delete(int? id)
        {
            BasketProductModel basket = Find(id);
            db.basketProducts.Remove(basket);
            db.SaveChanges();
            return true;
        }

        public List<BasketProductModel> GetAll()
        {
            return db.basketProducts.ToList();
        }

        public List<BasketProductModel> getBasketProducts(int? BasketModelId)
        {
            if(BasketModelId == null) { }
            List<BasketProductModel> basketProductList = db.basketProducts.ToList();
            List<BasketProductModel> listReturn = new List<BasketProductModel>();
            if(basketProductList.Count <= 0)
            {
            }
            else
            {
                foreach(var item in basketProductList)
                {
                    if(item.BasketModelId == BasketModelId)
                    {
                        listReturn.Add(item);
                    }
                }
            }
            return listReturn;
        }

        public bool InsertOrUpdate(BasketProductModel basket)
        {
            if(basket.Id <= 0)
            {
                db.basketProducts.Add(basket);
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