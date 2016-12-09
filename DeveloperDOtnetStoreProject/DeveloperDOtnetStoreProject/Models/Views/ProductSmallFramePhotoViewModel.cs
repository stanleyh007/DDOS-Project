using DeveloperDOtnetStoreProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Views
{
    public class ProductSmallFramePhotoViewModel
    {
        public int id { get; set; }
        public string BasicPathPicture { get; set; }
        public ProductModel product { get; set; }
    }
}