using DeveloperDOtnetStoreProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Store
{
    public class BasketModel
    {
        public int Id { get; set; }
        public List<BasketProductModel> products { get; set; }
        public double orderTotal { get; set; }
    }
}