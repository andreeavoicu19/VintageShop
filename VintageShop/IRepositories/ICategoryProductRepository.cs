﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IRepositories
{
    public interface ICategoryProductRepository : IGenericRepository<CategoryProduct>
    {
        Task<IEnumerable<CategoryProduct>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<CategoryProduct>> SearchProductWithCategory(string searchedValue);
    }
}
