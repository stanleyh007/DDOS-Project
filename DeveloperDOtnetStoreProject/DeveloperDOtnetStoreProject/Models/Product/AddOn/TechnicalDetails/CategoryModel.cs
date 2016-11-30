using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails
{
    public class CategoryModel
    {
        /**
         * Second lowest category
         * 1 step up and you will get CategoryHeaderModel
         */ 
        public int CategoryModelId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryHeaderModelId { get; set; }
        public CategoryHeaderModel CategoryHeaderModel { get; set; }
        public ICollection<CategoryItemModel> SubCategories { get; set; }
    }
}