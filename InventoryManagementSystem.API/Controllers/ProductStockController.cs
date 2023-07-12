using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly IProductStockService _productStockService;
        private readonly IMapper _mapper;

        public ProductStockController(IProductStockService productStockService, IMapper mapper)
        {
            _productStockService = productStockService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductStocks()
        {
            var productStocks = _productStockService.GetAllProductStocks();
            var productStocksDto = _mapper.Map<IEnumerable<ProductStock>>(productStocks);
            return Ok(productStocksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductStock(int id)
        {
            var productStock = await _productStockService.GetProductStock(id);
            var productStockDto = _mapper.Map<ProductStock>(productStock);
            return Ok(productStockDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductStock(ProductStockDto productStockDto)
        {
            var productStock = _mapper.Map<ProductStock>(productStockDto);
            await _productStockService.InsertProductStock(productStock);
            productStockDto = _mapper.Map<ProductStockDto>(productStock);
            return Ok(productStockDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductStock(int id, ProductStockDto productStockDto)
        {
            var productStock = _mapper.Map<ProductStock>(productStockDto);
            productStock.Id = id;
            await _productStockService.UpdateProductStock(productStock);
            productStockDto = _mapper.Map<ProductStockDto>(productStock);
            return Ok(productStockDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductStock(int id)
        {
            var result = await _productStockService.DeleteProductStock(id);
            return Ok(result);
        }
    }
}
