using DeveloperDOtnetStoreProject.Models.Product.AddOn;
using DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product
{
    public class ProductModel
    {
        public int ProductModelId { get; set; }
        public string NameHeader { get; set; }
        public string NameDescription { get; set; }
        public double Price { get; set; }
        public int QuantityStorage { get; set; }
        public int CategoryHModelId { get; set; }
        public CategoryHeaderModel CategoryHeaderModel { get; set; }
        public ICollection<CostumerReviewModel> Reviews { get; set; }
    }
}