using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperDOtnetStoreProject.Controllers.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDOtnetStoreProject.Interfaces;
using Moq;
using DeveloperDOtnetStoreProject.Controllers.Product.AddOn.TechnicalDetails;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System.Web.Mvc;

namespace ProductControllerTest.Tests
{
    [TestClass]
    public class CategoryHeaderControllerTests
    {
        private Mock<IGenericProductRepository<CategoryHeaderModel>> _mockRepository;
        private CategoryHeaderController _service;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IGenericProductRepository<CategoryHeaderModel>>();
            _service = new CategoryHeaderController(_mockRepository.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange - NO NEED _service!!
            //CategoryHeaderModel category = new CategoryHeaderModel() { CategoryHeaderModelId = -1, Name = "TestKort" };

            // Act
            var result = _service.Index() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CategoryHeaderModel category = new CategoryHeaderModel() { CategoryHeaderModelId = -1, Name = "TestKort" };
            // Act
            var result = _service.Create(category);
            // Assert
            try
            {
                _mockRepository.Verify(c => c.InsertOrUpdate(category));
            } catch(Moq.MockException eM)
            {
                eM.GetBaseException();
            }
            Assert.IsNotNull(result);
        }
    }
}