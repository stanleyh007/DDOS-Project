using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Views
{
    public class ProductCreateViewModel
    {
        public ProductModel Product { get; set; }
        public CategoryHeaderModel CategoryHeader { get; set; }
        public List<CategoryHeaderModel> categories { get; set; }
    }
}