using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails
{
    /**
     * This model is the loweste of them all, 
     * 1 step up and you will get CategoryModel
     */ 
    public class CategoryItemModel
    {
        public int Id { get; set; }
        public string HeaderName { get; set; }

        public int CategoryModelId { get; set; }
        public CategoryModel CategoryId { get; set; }

        public string ItemName { get; set; }
    }
}