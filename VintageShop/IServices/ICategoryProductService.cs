using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IServices
{
    public interface ICategoryProductService : IDisposable
    {
        Task<CategoryProduct> GetById(int id);
        Task<CategoryProduct> Add(CategoryProduct product);
        Task<CategoryProduct> Update(CategoryProduct product);
        Task<bool> Remove(CategoryProduct product);
        Task<IEnumerable<CategoryProduct>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<CategoryProduct>> SearchProductWithCategory(string searchedValue);
    }
}
