using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product;
using DeveloperDOtnetStoreProject.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Controllers.Store
{
    public class BasketController : Controller
    {
        private IProductRepository productRepository;
        private BasketModel basket;

        public BasketController(ProductRepository proRepo, BasketModel bask)
        {
            basket = bask;
            productRepository = proRepo;
            basket.orderTotal = 0;
        }
        // GET: Basket
        public ActionResult Index()
        {

            return View();
        }

        public void addOrUpdateBasket(ProductModel product)
        {
            Boolean succes = false;
            foreach(BasketProductModel bp in basket.products)
            {
                if(bp.Product == product)
                {
                    bp.Pieces++;
                    succes = true;
                }
            }
            if(!succes)
            {
                BasketProductModel bP = new BasketProductModel();
                bP.Product = product;
                basket.products.Add(bP);
            }
            basket.orderTotal += product.Price;
        }
    }
}