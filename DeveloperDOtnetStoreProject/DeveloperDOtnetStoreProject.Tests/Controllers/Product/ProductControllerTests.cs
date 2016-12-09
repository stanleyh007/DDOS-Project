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

namespace ProductControllerTest.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // IF
            // This could be the repository mock up
            // Arrange
            CategoryHeaderRepository categoryRepo = new CategoryHeaderRepository();
            ProductRepository productRepo = new ProductRepository();
            ProductController testControl = new ProductController(productRepo, categoryRepo);

            // Act
            ViewResult result = testControl.Index() as ViewResult;

            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void addNewCategoryHeaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HomepageIndexTest()
        {
            Assert.Fail();
        }
    }
}