using DeveloperDOtnetStoreProject.Models.User.AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string ForName { get; set; }
        public string LastName { get; set; }
        public string Adddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<WishListModel> WishList { get; set; }
        public ICollection<PurchaseModel> PurchaseHistory { get; set; }
    }
}