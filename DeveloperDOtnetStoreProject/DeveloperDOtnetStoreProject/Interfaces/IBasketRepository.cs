using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDOtnetStoreProject.Interfaces
{
    public interface IBasketRepository<T> where T : class
    {
        T Find(int? id);
        bool InsertOrUpdate(T model);
        bool Delete(int? id);
        List<T> GetAll();
    }
}
