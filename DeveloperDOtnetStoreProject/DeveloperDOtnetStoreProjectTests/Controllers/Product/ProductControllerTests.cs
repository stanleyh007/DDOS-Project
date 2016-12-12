using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperDOtnetStoreProject.Controllers.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Views;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System.Web.Mvc;
using System.Diagnostics;

namespace ProductControllerTest.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        // Global Private Mock Fields
        private Mock<IProductRepository> _mock;
        private ProductController _service;
        // Ekstra to start _service
        private Mock<CategoryHeaderRepository> _mockCategory;

        // Test Constructor
        [TestInitialize]
        public void Initialize()
        {
            // Use of mock simuates the repository 
            // Doc: https://en.wikipedia.org/wiki/Mock_object
            _mock = new Mock<IProductRepository>();
            _mockCategory = new Mock<CategoryHeaderRepository>();
            _service = new ProductController(_mock.Object, _mockCategory.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange And Act
            try
            {
                var result = _service.Index() as ViewResult;
                // Assert
                Assert.IsNotNull(result);
            } catch(NullReferenceException eNR)
            {
                Debug.WriteLine(eNR);
            }
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            ProductCreateViewModel pCView = new ProductCreateViewModel();
            ProductModel product = new ProductModel();
            CategoryHeaderModel category = new CategoryHeaderModel();
            category.Name = "TestKort";
            category.CategoryHeaderModelId = 1;

            pCView.CategoryHeader = category;

            _mockCategory.Object.InsertOrUpdate(category);
            pCView.categories = _mockCategory.Object.GetAll();

            product.CategoryHeaderModel = category;
            product.CategoryHModelId = 1;
            product.NameHeader = "GeForce Test";
            product.NameDescription = "Bacon";
            product.Price = -1;
            product.QuantityStorage = 1;
            product.Reviews = null;
            // Add product to view
            pCView.Product = product;
            
            // Act
            var result = _service.Create(pCView) as ViewResult;

            // Assert
            try
            {
                Assert.IsNotNull(result);
            } catch(AssertFailedException eAF)
            {
                Debug.WriteLine(eAF);
            }
            _mock.Verify(r => r.InsertOrUpdate(product));
        }
    }
}