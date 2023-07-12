using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = _productService.GetAllProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.InsertProduct(product);
            productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
            await _productService.UpdateProduct(product);
            productDto = _mapper.Map<ProductDto>(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
