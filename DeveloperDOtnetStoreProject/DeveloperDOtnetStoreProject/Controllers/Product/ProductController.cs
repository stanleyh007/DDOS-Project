using DeveloperDOtnetStoreProject.Models.Product;
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
using DeveloperDOtnetStoreProject.Models.Views;
using System.Diagnostics;

namespace DeveloperDOtnetStoreProject.Controllers.Product
{
    public class ProductController : Controller
    {
        // DROPDOWN
        private ProductCreateViewModel viewModel = new ProductCreateViewModel();

        ProductHomepageViewModel productHpVModel;
        private IGenericProductRepository<CategoryHeaderModel> categoryHeaderRepository;
        
        // IF ninject dosn't work here remove 
        //using DeveloperDOtnetStoreProject.Interfaces;
        private IProductRepository productRepository;
        public ProductController(ProductRepository iprepo, CategoryHeaderRepository cHR)
        {
            categoryHeaderRepository = cHR;
            productRepository = iprepo;
            productHpVModel = new ProductHomepageViewModel();
        }

        [AllowAnonymous]
        // GET: Product
        public ActionResult Index()
        {
            return View(getProductViewModel());
            //return View(productRepository.GetAll());
        }

        private ProductHomepageViewModel getProductViewModel()
        {
            productHpVModel.categoryHeaders = categoryHeaderRepository.GetAll();
            productHpVModel.products = productRepository.GetAll();
            productHpVModel.hereAreYou = "Produkter";
            productHpVModel.header = "Produkter";
            productHpVModel.products = addCategoryHeaderModel(productHpVModel.products);

            return productHpVModel;
        }

        private List<ProductModel> addCategoryHeaderModel(List<ProductModel> list)
        {
            
            List<ProductModel> valueReturn = new List<ProductModel>();
            
            foreach(var item in list)
            {
                CategoryHeaderModel cate = categoryHeaderRepository.Find(item.CategoryHModelId);
                item.CategoryHeaderModel = cate;
                valueReturn.Add(item);
            }

            foreach(var itemDB in valueReturn)
            {
                productRepository.InsertOrUpdate(itemDB);
            }

            return valueReturn;
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
            ProductCreateViewModel productView = fullData(null);
            // Virker ikke Endnu
            //ViewBag.CategoryModelId = new SelectList(ListCategoryHeaderModels, "CategoryModelId", "CategoryName");
            return View(productView);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductCreateViewModel productView)
        {
            if (ModelState.IsValid)
            {
                CategoryHeaderModel productCategory = categoryHeaderRepository.Find(productView.Product.CategoryHModelId);
                productView.Product.CategoryHeaderModel = productCategory;
                // product is created
                productRepository.InsertOrUpdate(productView.Product);
                
                return RedirectToAction("Index");
            }
            
            return View();
        }

        // DROPDOWN Controller
        private ProductCreateViewModel fullData(int? id)
        {
            ProductCreateViewModel valueReturn = new ProductCreateViewModel();
            if (productRepository.Find(id) != null)
            {
                valueReturn.Product = productRepository.Find(id);
            } else
            {
                valueReturn.Product = new ProductModel();
            }
            
            valueReturn.categories = categoryHeaderRepository.GetAll();
            
            return valueReturn;
        }

        // With Use of Dropdown View
        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            // replaced
            //ProductModel product = productRepository.Find(id);
            ProductCreateViewModel productView = fullData(id);
            if(productView == null)
            {
                return new HttpNotFoundResult();
            }
            Debug.WriteLine(productView);
            return View(productView);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCreateViewModel productView)
        {
            if(ModelState.IsValid) {
                productRepository.InsertOrUpdate(productView.Product);

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

        // POST: CategoryHeader/Edit/5
        [HttpPost]
        public ActionResult addNewCategoryHeader(ProductCreateViewModel pcvm)
        {
            CategoryHeaderModel category = pcvm.CategoryHeader;
            categoryHeaderRepository.InsertOrUpdate(category);
            return Redirect(Request.UrlReferrer.ToString());
        }

        // To Get View to Body by getting relevant data listed:
        // - CategoryHeaderModel
        // - Products
        public ActionResult HomepageIndex()
        {
            return View(getView());
        }

        private ProductHomepageViewModel getView()
        {
            ProductHomepageViewModel viewReturn = new ProductHomepageViewModel();
            viewReturn.categoryHeaders = categoryHeaderRepository.GetAll();
            viewReturn.products = productRepository.GetAll();
            viewReturn.hereAreYou = " Home";
            viewReturn.header = "Hardware";
            return viewReturn;
        }
    }
}
