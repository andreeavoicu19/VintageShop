using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IServices
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Remove(Category category);
        Task<IEnumerable<Category>> Search(string categoryName);
    }
}
