using DeveloperDOtnetStoreProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Store
{
    public class BasketProductModel
    {
        public int Id { get; set; }
        public int BasketModelId { get; set; }
        public ProductModel Product { get; set; }
        public int Pieces { get; set; }
        public double Price { get; set; }
    }
}