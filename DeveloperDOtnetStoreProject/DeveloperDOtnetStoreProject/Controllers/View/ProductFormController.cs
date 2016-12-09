using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product;
using DeveloperDOtnetStoreProject.Models.Views;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Repositories;
using DeveloperDOtnetStoreProject.Models.User;

namespace DeveloperDOtnetStoreProject.Controllers.Views
{
    public class ProductFormController : Controller
    {
        private IProductRepository productRepository;
        private ProductSmallFramePhotoViewModel photoViewModel;
        private List<ProductSmallFramePhotoViewModel> viewList;

        private IGenericProductRepository<CategoryHeaderModel> categoryHeaderRepository;

        public ProductFormController(ProductRepository pRepo, ProductSmallFramePhotoViewModel pvm, CategoryHeaderRepository chr)
        {
            categoryHeaderRepository = chr;
            productRepository = pRepo;
            photoViewModel = pvm;
            viewList = new List<ProductSmallFramePhotoViewModel>();
            populateViewModel();
        }

        // Populates ViewList with ALL products
        private void populateViewModel()
        {
            List<ProductModel> list = productRepository.GetAll();
            foreach(ProductModel p in list) {
                ProductSmallFramePhotoViewModel viewModel = new ProductSmallFramePhotoViewModel();
                viewModel.product = p;
                viewModel.BasicPathPicture = "Images/Hardware/";
                viewList.Add(viewModel);
            }
        }

        public ActionResult Index()
        {
            return View(viewList);
        }

        // Render Productlists From category
        public ActionResult HomepageCategory(int? id)
        {
            if(id == null) { return new HttpNotFoundResult(); }

            return View(getCategoryView(id));
        }

        private ProductHomepageCategoryViewModel getCategoryView(int? categoryId)
        {
            ProductHomepageCategoryViewModel objectReturn = new ProductHomepageCategoryViewModel();
            List<ProductModel> list = productRepository.GetAll();
            foreach (ProductModel p in list)
            {
                objectReturn.category = categoryHeaderRepository.Find(categoryId);
                objectReturn.categories = categoryHeaderRepository.GetAll();
                objectReturn.header = objectReturn.category.Name;
                objectReturn.hereAreYou = " > Hardware";
                objectReturn.BasicPathPicture = "Images/Hardware/";
                objectReturn.products = new List<ProductModel>();
                /* Filters the list to the list of this Category */
                foreach(var item in list)
                {
                    // If true then put product in objectReturn.products
                    if(categoryId == item.CategoryHModelId && (categoryHeaderRepository.Find(item.CategoryHModelId)) != null)
                    {
                        int a = item.CategoryHModelId;
                        objectReturn.products.Add(item);
                    }
                }
            }
            return objectReturn;
        }

        [HttpGet]
        // To get the model for the product Details View
        // Add int? id of User
        // Try with userId and productId
        public ActionResult HomepageProductDetails(int? id)
        {
            if(id == null)
            {
                return new HttpNotFoundResult();
            }
            ProductModel product = productRepository.Find(id);
            if(product == null)
            {
                return View(new ProductModel());
            }
            // Adding categoryHeaderModel
            product.CategoryHeaderModel = categoryHeaderRepository.Find(product.CategoryHModelId);
            return View(product);
        }

        [HttpPost]
        public ActionResult HomepageProductDetails(ProductModel product)
        {

            // Go to CostumerReview Create
            return View();
        }
    }
}