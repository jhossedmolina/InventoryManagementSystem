using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = _productCategoryService.GetAllProductCategories();
            var productCategoriesDto = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);
            return Ok(productCategoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategory(int id)
        {
            var productCategory = await _productCategoryService.GetProductCategoryById(id);
            var productCategoryDto = _mapper.Map<ProductCategoryDto>(productCategory);
            return Ok(productCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductCategory(ProductCategoryDto productCategoryDto)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryDto);
            await _productCategoryService.InsertProductCategory(productCategory);
            productCategoryDto = _mapper.Map<ProductCategoryDto>(productCategory);
            return Ok(productCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategoryDto productCategoryDto)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryDto);
            productCategory.Id = id;
            await _productCategoryService.UpdateProductCategory(productCategory);
            return Ok(productCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var result = await _productCategoryService.DeleteProductCategory(id);
            return Ok(result);
        }
    }
}
