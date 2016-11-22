using DeveloperDOtnetStoreProject.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDOtnetStoreProject.Models.Product.AddOn
{
    public class CostumerReviewModel
    {
        public int CostumerReviewModelId { get; set; }
        public UserModel UserModelId { get; set; }
        public string Review { get; set; }
        public RatingModel RatingModelId { get; set; }
    }
}