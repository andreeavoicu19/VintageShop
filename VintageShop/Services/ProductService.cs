using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;
using VintageShop.IServices;
using VintageShop.IRepositories;

namespace VintageShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> Add(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name).Result.Any())
                return null;

            await _productRepository.Add(product);
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name && b.Id != product.Id).Result.Any())
                return null;

            await _productRepository.Update(product);
            return product;
        }

        public async Task<bool> Remove(Product product)
        {
            await _productRepository.Remove(product);
            return true;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await _productRepository.GetProductsByCategory(categoryId);
        }

        public async Task<IEnumerable<Product>> Search(string productName)
        {
            return await _productRepository.Search(c => c.Name.Contains(productName));
        }

        public async Task<IEnumerable<Product>> SearchProductWithCategory(string searchedValue)
        {
            return await _productRepository.SearchProductWithCategory(searchedValue);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
