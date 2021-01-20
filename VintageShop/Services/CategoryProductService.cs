using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;
using VintageShop.IServices;
using VintageShop.IRepositories;

namespace VintageShop.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ICategoryProductRepository _categoryproductRepository;

        public CategoryProductService(ICategoryProductRepository categoryproductRepository)
        {
            _categoryproductRepository = categoryproductRepository;
        }

        public async Task<CategoryProduct> GetById(int id)
        {
            return await _categoryproductRepository.GetById(id);
        }

        public async Task<CategoryProduct> Add(CategoryProduct product)
        {
            if (_categoryproductRepository.Search(b => b.Id == product.Id).Result.Any())
                return null;

            await _categoryproductRepository.Add(product);
            return product;
        }

        public async Task<CategoryProduct> Update(CategoryProduct product)
        {
            if (_categoryproductRepository.Search(b => b.Id == product.Id && b.Id != product.Id).Result.Any())
                return null;

            await _categoryproductRepository.Update(product);
            return product;
        }

        public async Task<bool> Remove(CategoryProduct product)
        {
            await _categoryproductRepository.Remove(product);
            return true;
        }

        public async Task<IEnumerable<CategoryProduct>> GetProductsByCategory(int categoryId)
        {
            return await _categoryproductRepository.GetProductsByCategory(categoryId);
        }

        public async Task<IEnumerable<CategoryProduct>> SearchProductWithCategory(string searchedValue)
        {
            return await _categoryproductRepository.SearchProductWithCategory(searchedValue);
        }

        public void Dispose()
        {
            _categoryproductRepository?.Dispose();
        }
    }
}
