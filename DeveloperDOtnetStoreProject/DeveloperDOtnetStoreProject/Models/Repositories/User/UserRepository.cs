using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.Product;
using DeveloperDOtnetStoreProject.Models.User;
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
        public void InsertOrUpdate(ApplicationUser model)
        {
                

            try
            {
                if(model.Id == null)
                {
                    db.Users.Add(model);
                }
                else
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
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