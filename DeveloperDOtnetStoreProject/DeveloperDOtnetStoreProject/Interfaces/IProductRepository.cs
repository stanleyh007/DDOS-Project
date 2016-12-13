using DeveloperDOtnetStoreProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDOtnetStoreProject.Interfaces
{
    public interface IProductRepository
    {
        ProductModel Find(int? id);
        List<ProductModel> GetAll();
        void InsertOrUpdate(ProductModel product);
        bool Delete(int? id);
        List<ProductModel> SearchProducts(string search);
    }
}
