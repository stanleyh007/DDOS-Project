using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails
{
    public class CategoryItemModel
    {
        public int Id { get; set; }
        public string HeaderName { get; set; }
        public string ItemName { get; set; }
        public bool isItemNameUSed { get; set; }
        public ICollection<string> ItemNames { get; set; }
    }
}