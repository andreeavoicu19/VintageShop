using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IServices;
using VintageShop.Models;
using VintageShop.DTOs;
using AutoMapper;

namespace VintageShop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper,
                                IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProductResultDTO>>(products));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductResultDTO>(product));
        }

        [HttpGet]
        [Route("get-products-by-category/{categoryId:int}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategory(categoryId);

            if (!products.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ProductResultDTO>>(products));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDTO productDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(productDTO);
            var productResult = await _productService.Add(product);

            if (productResult == null) return BadRequest();

            return Ok(_mapper.Map<ProductResultDTO>(productResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductEditDTO productDTO)
        {
            if (id != productDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _productService.Update(_mapper.Map<Product>(productDTO));

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null) return NotFound();

            await _productService.Remove(product);

            return Ok();
        }

        [Route("search/{productName}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Search(string productName)
        {
            var products = _mapper.Map<List<Product>>(await _productService.Search(productName));

            if (products == null || products.Count == 0) return NotFound("No product was found.");

            return Ok(products);
        }

        [Route("search-product-with-category/{searchedValue}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> SearchProductWithCategory(string searchedValue)
        {
            var products = _mapper.Map<List<Product>>(await _productService.SearchProductWithCategory(searchedValue));

            if (!products.Any()) return NotFound("No product was found.");

            return Ok(_mapper.Map<IEnumerable<ProductResultDTO>>(products));
        }
    }
}
