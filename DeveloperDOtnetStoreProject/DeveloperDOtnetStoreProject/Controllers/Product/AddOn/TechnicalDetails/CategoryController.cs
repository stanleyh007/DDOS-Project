using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn.TechnicalDetails;

namespace DeveloperDOtnetStoreProject.Controllers.Product.AddOn.TechnicalDetails
{
    [Authorize]
    public class CategoryController : Controller
    {
        private IGenericProductRepository<CategoryModel> repository;

        public CategoryController(CategoryRepository iprepo)
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
            CategoryModel entity = repository.Find(id);
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
        public ActionResult Create(CategoryModel entity)
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
            CategoryModel entity = repository.Find(id);

            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            return View(entity);
        }

        // POST: CostumerReview/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryModel entity)
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

        public CategoryModel Find(int? id)
        {
            return repository.Find(id);
        }
    }
}