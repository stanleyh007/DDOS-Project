﻿using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Controllers.Product.AddOn
{
    public class CostumerReviewController : Controller
    {
        private IGenericProductRepository<CostumerReviewModel> repository;

        public CostumerReviewController(CostumerReviewRepository iprepo)
        {
            repository = iprepo;
        }

        [AllowAnonymous]
        // GET: CostumerReview
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: CostumerReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostumerReviewModel entity = repository.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // GET: CostumerReview/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostumerReview/Create
        [HttpPost]
        public ActionResult Create(CostumerReviewModel entity)
        {
            if (ModelState.IsValid)
            {
                // product is created
                repository.InsertOrUpdate(entity);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: CostumerReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            CostumerReviewModel entity = repository.Find(id);

            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            return View(entity);
        }

        // POST: CostumerReview/Edit/5
        [HttpPost]
        public ActionResult Edit(CostumerReviewModel entity)
        {
            if (ModelState.IsValid)
            {
                repository.InsertOrUpdate(entity);
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public CostumerReviewModel Find(int? id)
        {
            return repository.Find(id);
        }
    }
}