using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IServices;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;
using Microsoft.EntityFrameworkCore;

namespace VintageShop.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext context) : base(context) { }

        public override async Task<List<Product>> GetAll()
        {
            return await Db.Products.AsNoTracking().Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public override async Task<Product> GetById(int id)
        {
            return await Db.Products.AsNoTracking().Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Product>> SearchProductWithCategory(string searchedValue)
        {
            return await Db.Products.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }
    }
}