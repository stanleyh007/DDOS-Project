using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Controllers.Product.AddOn
{
    [Authorize]
    public class CategoryHeaderController : Controller
    {
        private CategoryHeaderRepository categoryRepo;
        private IGenericProductRepository<CategoryHeaderModel> _repository;

        public CategoryHeaderController(IGenericProductRepository<CategoryHeaderModel> cate)
        {
            _repository = cate;
            categoryRepo = new CategoryHeaderRepository();
        }

        [AllowAnonymous]
        // GET: CategoryHeader
        public ActionResult Index()
        {
            return View(categoryRepo.GetAll());
        }

        // Don't even know hos to put in the game
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(CategoryHeaderModel cHeader)
        {
            if(ModelState.IsValid)
            {
                categoryRepo.InsertOrUpdate(cHeader);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}