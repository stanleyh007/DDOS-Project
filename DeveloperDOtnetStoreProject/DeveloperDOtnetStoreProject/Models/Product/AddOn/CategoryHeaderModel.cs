using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn
{
    public class CategoryHeaderModel
    {
        public int CategoryHeaderModelId { get; set; }
        public string Name { get; set; } // name of the product
        public ICollection<CategoryModel> Categories { get; set; }
    }
}