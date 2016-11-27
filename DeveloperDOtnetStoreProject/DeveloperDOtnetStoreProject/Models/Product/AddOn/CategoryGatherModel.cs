using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn
{
    public class CategoryGatherModel
    {
        public int Id { get; set; }
        public CategoryHeaderModel CategoryHeader { get; set; }
        public ICollection<CategoryModel> CategoryModels { get; set; }
    }
}