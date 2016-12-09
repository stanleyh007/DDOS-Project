using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
           return db.Users.Find(id);
        }

        //Get all users
          public List<ApplicationUser> GetAll()
        {
            List<ApplicationUser> users = db.Users.ToList();
            return users;
        }

        //Add or edit
        public void Update(EditViewModel model)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == model.Id);
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PostalCode = model.PostalCode;
                user.City = model.City;
                user.Address = model.Address;
            }
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
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
                db.Users.Remove(user);
            }

            db.SaveChanges();
            return true;
        }
    }
}