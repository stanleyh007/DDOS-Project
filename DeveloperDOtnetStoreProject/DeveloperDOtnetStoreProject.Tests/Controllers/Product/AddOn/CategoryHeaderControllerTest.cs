using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Controllers.Product.AddOn;
using Moq;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Repositories.Product.AddOn;

namespace DeveloperDOtnetStoreProject.Tests.Controllers.Product.AddOn
{
    [TestClass]
    public class CategoryHeaderControllerTest
    {
        private Mock<IGenericProductRepository<CategoryHeaderModel>> _ICategoryHeaderRepo;
        private CategoryHeaderController _service;

        [TestInitialize]
        public void Initialize()
        {
            _ICategoryHeaderRepo = new Mock<IGenericProductRepository<CategoryHeaderModel>>();
            _service = new CategoryHeaderController(_ICategoryHeaderRepo.Object);
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            var category = new CategoryHeaderModel();
            category.Name = "TestKort";
            category.CategoryHeaderModelId = -1;

            // Act
            _service.Create(category);

            // Assert
            _ICategoryHeaderRepo.Verify(r => r.InsertOrUpdate(category));
        }
    }
}
