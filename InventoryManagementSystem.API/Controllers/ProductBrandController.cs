using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;

        public ProductBrandController(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductBrands()
        {
            var productBrands = _productBrandService.GetAllProductBrands();
            var productBrandDto = _mapper.Map<IEnumerable<ProductBrandDto>>(productBrands);
            return Ok(productBrandDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductBrand(int id)
        {
            var productBrand = await _productBrandService.GetProductBrandById(id);
            var productBrandDto = _mapper.Map<ProductBrandDto>(productBrand);
            return Ok(productBrandDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductBrand(ProductBrandDto productBrandDto)
        {
            var productBrand = _mapper.Map<ProductBrand>(productBrandDto);
            await _productBrandService.InsertProductBrand(productBrand);
            productBrandDto = _mapper.Map<ProductBrandDto>(productBrand);
            return Ok(productBrandDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBrand(int id, ProductBrandDto productBrandDto)
        {
            var productBrand = _mapper.Map<ProductBrand>(productBrandDto);
            productBrand.Id = id;
            await _productBrandService.UpdateProductBrand(productBrand);
            productBrandDto = _mapper.Map<ProductBrandDto>(productBrand);
            return Ok(productBrandDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBrand(int id)
        {
            var result = await _productBrandService.DeleteProductBrand(id);
            return Ok(result);
        }

    }
}
 