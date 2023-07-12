using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHistoryController : ControllerBase
    {
        private readonly IProductHistoryService _productHistoryService;
        private readonly IMapper _mapper;

        public ProductHistoryController(IProductHistoryService productHistoryService, IMapper mapper)
        {
            _productHistoryService = productHistoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductHistory()
        {
            var productHistory = _productHistoryService.GetProductHistory();
            var productHistoryDto = _mapper.Map<IEnumerable<ProductHistoryDto>>(productHistory);
            return Ok(productHistoryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductHistory(int id)
        {
            var productHistory = await _productHistoryService.GetProductHistory(id);
            var productHistoryDto = _mapper.Map<ProductHistoryDto>(productHistory);
            return Ok(productHistoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductHistory(ProductHistoryDto productHistoryDto)
        {
            var productHistory = _mapper.Map<ProductHistory>(productHistoryDto);
            await _productHistoryService.InsertProductHistory(productHistory);
            productHistoryDto = _mapper.Map<ProductHistoryDto>(productHistory);
            return Ok(productHistoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductHistory(int id, ProductHistoryDto productHistoryDto)
        {
            var productHistory = _mapper.Map<ProductHistory>(productHistoryDto);
            productHistory.Id = id;
            await _productHistoryService.UpdateProductHistory(productHistory);
            productHistoryDto = _mapper.Map<ProductHistoryDto>(productHistory);
            return Ok(productHistoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductHistory(int id)
        {
            var result = await _productHistoryService.DeleteProductHistory(id);
            return Ok(result);
        }
    }
}
