using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IServices;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;

namespace VintageShop.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext context) : base(context) { }
    }
}