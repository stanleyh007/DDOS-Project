using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDOtnetStoreProject.Models.User;

namespace DeveloperDOtnetStoreProject.Interfaces
{
    interface IUserRepository
    {
        UserModel Find(int? id);
        List<UserModel> GetAll();
        void InsertOrUpdate(UserModel user);
        bool Delete(int? id);
    }
}
