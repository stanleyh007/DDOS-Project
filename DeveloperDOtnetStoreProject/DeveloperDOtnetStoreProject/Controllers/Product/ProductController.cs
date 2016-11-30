﻿using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Net;
using DeveloperDOtnetStoreProject.Models.Repositories.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;

namespace DeveloperDOtnetStoreProject.Controllers.Product
{
    public class ProductController : Controller
    {
        private List<CategoryHeaderModel> ListCategoryHeaderModels;
        // IF ninject dosn't work here remove 
        //using DeveloperDOtnetStoreProject.Interfaces;
        private IProductRepository productRepository;
        public ProductController(ProductRepository iprepo, CategoryHeaderRepository cHR)
        {
            ListCategoryHeaderModels = cHR.GetAll();
            productRepository = iprepo;
        }

        [AllowAnonymous]
        // GET: Product
        public ActionResult Index()
        {
            return View(productRepository.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel product = productRepository.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Virker ikke Endnu
            ViewBag.CategoryModelId = new SelectList(ListCategoryHeaderModels, "CategoryModelId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                // product is created
                productRepository.InsertOrUpdate(product);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpNotFoundResult();
            }
            ProductModel product = productRepository.Find(id);

            if(product == null)
            {
                return new HttpNotFoundResult();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if(ModelState.IsValid) {
                productRepository.InsertOrUpdate(product);
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }   
            return View();
        }
        
        // POST: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpNotFoundResult();
            }
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ProductModel Find(int? id)
        {
            return productRepository.Find(id);
        }
    }
}
