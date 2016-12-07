using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace DeveloperDOtnetStoreProject.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      
        //Find specific user
        public ApplicationUser Find(string id)
        {
           return db.UserModels.Find(id);
        }

        //Get all users
          public List<ApplicationUser> GetAll()
        {
            List<ApplicationUser> users = db.UserModels.ToList();
            return users;
        }

        //Add or edit
        public void InsertOrUpdate(ApplicationUser model)
        {
            if (model.Id == null)
            {
                db.UserModels.Add(model);
            }
            else
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
        }

        //Delete user
        public bool Delete(string id)
        {
            if (id == null)
            {
                System.Diagnostics.Debug.WriteLine("This Id does not exist");
                return false;
            }
            else
            {
                ApplicationUser user = Find(id);
                db.UserModels.Remove(user);
            }

            db.SaveChanges();
            return true;
        }
    }
}