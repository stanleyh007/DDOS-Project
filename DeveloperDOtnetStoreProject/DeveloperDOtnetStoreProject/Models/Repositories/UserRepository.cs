using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDOtnetStoreProject.Interfaces;
using DeveloperDOtnetStoreProject.Models.User;

namespace DeveloperDOtnetStoreProject.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Find specific user
        public UserModel Find(int? id)
        {
           return db.UserModels.Find(id);
        }

        //Get all users
          public List<UserModel> GetAll()
        {
            List<UserModel> users = db.UserModels.ToList();
            return users;
        }

        //Add or edit
        public void InsertOrUpdate(UserModel user)
        {
            if (user.Id <= 0)
            {
                db.UserModels.Add(user);
            }
            else
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

        //Delete user
        public bool Delete(int? id)
        {
            if (id <= 0)
            {
                System.Diagnostics.Debug.WriteLine("This Id does not exist");
                return false;
            }
            else
            {
                UserModel user = Find(id);
                db.UserModels.Remove(user);
            }

            db.SaveChanges();
            return true;
        }  
    }
}