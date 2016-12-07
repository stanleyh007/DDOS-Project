using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDOtnetStoreProject.Models;

namespace DeveloperDOtnetStoreProject.Interfaces
{
    interface IUserRepository
    {
        ApplicationUser Find(string id);
        List<ApplicationUser> GetAll();
        void InsertOrUpdate(ApplicationUser user);
        bool Delete(string id);
    }
}
