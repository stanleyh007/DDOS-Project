using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
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
        
        // This variable is not usable
        //public ICollection<CategoryModel> Categories { get; set; }
    }
}