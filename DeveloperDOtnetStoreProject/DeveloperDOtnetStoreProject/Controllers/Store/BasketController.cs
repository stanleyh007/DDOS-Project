using DeveloperDOtnetStoreProject.Controllers.Views;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn.TechnicalDetails;
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
            basket.products = new List<BasketProductModel>();
        }
        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool addPToBasket(int? id, int? pieces)
        {
            for(int a=0; a < pieces; a++)
            {
                addProductToBasket(id);
            }

            if(pieces == null)
            {
                addProductToBasket(id);
            }

            //return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            return true;
        }

        public void addProductToBasket(int? productId)
        {
            CategoryHeaderRepository categoryRepo = new CategoryHeaderRepository();
            ProductModel basketProduct = productRepository.Find(productId);
            basketProduct.CategoryHeaderModel = categoryRepo.Find(basketProduct.CategoryHModelId);
            updatePlusBasket(basketProduct);
        }

        private void updatePlusBasket(ProductModel model)
        {
            basket.orderTotal += model.Price;
            basket.pieces++;
            BasketProductModel basketItem = new BasketProductModel();
            basketItem.Product = model;
            basketItem.Price = model.Price;
            basketItem.Pieces += 1;
            basket.products.Add(basketItem);
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

        /* Getter for the Cart when you wanna buy content */
        [HttpGet]
        public ActionResult cartBuy(BasketModel basketModel)
        {
            /* PARAMETERS:
                - BasketModel
                - UserId if some
             */
            return View();
        }
    }
}