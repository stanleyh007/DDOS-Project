using DeveloperDOtnetStoreProject.Interfaces;
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
    [Authorize]
    public class RatingController : Controller
    {
        private IGenericProductRepository<RatingModel> repository;

        public RatingController(RatingRepository iprepo)
        {
            repository = iprepo;
        }

        [AllowAnonymous]
        // GET: Rating
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Rating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingModel entity = repository.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // GET: Rating/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(RatingModel entity)
        {
            if (ModelState.IsValid)
            {
                // product is created
                repository.InsertOrUpdate(entity);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            RatingModel entity = repository.Find(id);

            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            return View(entity);
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(RatingModel entity)
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

        public RatingModel Find(int? id)
        {
            return repository.Find(id);
        }
    }
}