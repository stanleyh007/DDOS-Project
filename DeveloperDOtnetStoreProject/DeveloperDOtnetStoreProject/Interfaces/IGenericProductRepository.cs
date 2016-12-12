using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDOtnetStoreProject.Interfaces
{
    public interface IGenericProductRepository<T> where T : class 
    {
        T Find(int? id);
        List<T> GetAll();
        bool InsertOrUpdate(T entity);
        bool Delete(int? id);
    }
}
