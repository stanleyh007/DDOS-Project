using DeveloperDOtnetStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Controllers.Product.AddOn
{
    public class CategoryHeaderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CategoryHeader
        public ActionResult Index()
        {
            return View(db.CategoryHeader.ToList());
        }
    }
}