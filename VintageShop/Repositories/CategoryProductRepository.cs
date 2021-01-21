using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;
using Microsoft.EntityFrameworkCore;

namespace VintageShop.Repositories
{
    public class CategoryProductRepository : GenericRepository<CategoryProduct>, ICategoryProductRepository
    {
        public CategoryProductRepository(StoreDbContext context) : base(context) { }

        public override async Task<CategoryProduct> GetById(int id)
        {
            return await Db.CategoryProducts.AsNoTracking().Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CategoryProduct>> GetProductsByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<CategoryProduct>> SearchProductWithCategory(string searchedValue)
        {
            return await Db.CategoryProducts.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.ProductId.Equals(searchedValue) ||
                            b.CategoryId.Equals(searchedValue))
                .ToListAsync();
        }
    }
}
