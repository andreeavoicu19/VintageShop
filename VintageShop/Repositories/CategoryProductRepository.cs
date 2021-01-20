using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;

namespace VintageShop.Repositories
{
    public class CategoryProductRepository : GenericRepository<CategoryProduct>, ICategoryProductRepository
    {
        public CategoryProductRepository(StoreDbContext context) : base(context) { }
    }
}
