using DeveloperDOtnetStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.User;
using DeveloperDOtnetStoreProject.Models.User.AddOn;
using AutoMapper;

namespace DeveloperDOtnetStoreProject.Controllers.User.AddOn
{
    public class WishlistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Wishlist
        public ActionResult Index()
        {
            return View(db.WishList.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            WishListModel wishlish = Mapper.Map<ProductModel, WishListModel>(product);
            db.WishList.Add(wishlish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}