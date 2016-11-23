using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails
{
    public class CategoryModel
    {
        public int CategoryModelId { get; set; }
        public string CategoryName { get; set; }
        public CategoryHeaderModel CategoryHeaderModelId { get; set; }
        public ICollection<CategoryItemModel> SubCategories { get; set; }
    }
}