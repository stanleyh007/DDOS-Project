﻿using DeveloperDOtnetStoreProject.Models.Product.AddOn;
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
        public CategoryHeaderModel CategoryHeaderModelId { get; set; }
        public ICollection<CostumerReviewModel> Reviews { get; set; }
    }
}