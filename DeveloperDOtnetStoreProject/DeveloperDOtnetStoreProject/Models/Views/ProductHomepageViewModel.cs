using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Views
{
    public class ProductHomepageViewModel
    {
        public string header { get; set; }
        public string hereAreYou { get; set; }
        public List<CategoryHeaderModel> categoryHeaders { get; set; }
        public List<ProductModel> products { get; set; }
    }
}