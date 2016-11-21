using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Models.Product;

namespace DeveloperDOtnetStoreProject.Models.User.AddOn
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double price { get; set; }
        public int Quantity { get; set; }
        public ProductModel ProductModelId { get; set; }

        public ProductModel ProductNameHeader { get; set; }

    }
}