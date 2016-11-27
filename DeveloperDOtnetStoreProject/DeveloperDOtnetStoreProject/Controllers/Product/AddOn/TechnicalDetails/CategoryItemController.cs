﻿using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Controllers.Product.AddOn.TechnicalDetails
{
    [Authorize]
    public class CategoryItemController : Controller
    {
        private CategoryItemRepository repository = new CategoryItemRepository();

        [AllowAnonymous]
        // GET: CategoryItem
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // Don't even know hos to put in the game
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(repository.Find(id));
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(CategoryItemModel cItem)
        {
            if (ModelState.IsValid)
            {
                repository.InsertOrUpdate(cItem);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}