using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Models.Product;

namespace DeveloperDOtnetStoreProject.Models.User.AddOn
{
    public class WishListModel
    {
        public int WishListModelId { get; set; }
        public ProductModel ProductModelId { get; set; }
        public virtual ApplicationUser UserModelId { get; set; }
    }
}