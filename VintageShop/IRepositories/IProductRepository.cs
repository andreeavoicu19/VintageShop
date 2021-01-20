using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        new Task<List<Product>> GetAll();
        new Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<Product>> SearchProductWithCategory(string searchedValue);
    }
}
