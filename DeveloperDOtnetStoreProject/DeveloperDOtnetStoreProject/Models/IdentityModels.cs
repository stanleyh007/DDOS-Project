using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DeveloperDOtnetStoreProject.Models.User;

namespace DeveloperDOtnetStoreProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // Identity User
        public UserModel UserModel { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        // Product
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.ProductModel> Products { get; set; }
        // -> AddOn 
        //    -> CategoryHeaderModel
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.AddOn.CategoryHeaderModel> CategoryHeader { get; set; }
        //    -> CostumerReview
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.AddOn.CostumerReviewModel> CostumerReview { get; set; }

        // -> TechnicalDetails 
        //    -> CategoryItemModel
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails.CategoryItemModel> CategoryItem { get; set; }
        //    -> CategoryModel
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails.CategoryModel> Category { get; set; }



        //public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.Product.AddOn.TechnicalDetails.CategoryItemModel> CategoryItemModels { get; set; }
        // User
        public System.Data.Entity.DbSet<DeveloperDOtnetStoreProject.Models.User.UserModel> UserModels { get; set; }
    }
}