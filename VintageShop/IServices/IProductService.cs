using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IServices
{
     public interface IProductService : IDisposable
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Remove(Product product);
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<Product>> Search(string productName);
        Task<IEnumerable<Product>> SearchProductWithCategory(string searchedValue);
    }
}
