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
    public class ProductMovementController : ControllerBase
    {
        private IProductMovementService _productMovementService;
        private IMapper _mapper;

        public ProductMovementController(IProductMovementService productMovementService, IMapper mapper)
        {
            _productMovementService = productMovementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductMovements()
        {
            var productMovements = _productMovementService.GetProductMovements();
            var productMovementsDto = _mapper.Map<IEnumerable<ProductMovementDto>>(productMovements);
            return Ok(productMovementsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductMovement(int id)
        {
            var productMovement = await _productMovementService.GetProductMovement(id);
            var productMovementDto = _mapper.Map<ProductMovementDto>(productMovement);
            return Ok(productMovementDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductMovement(ProductMovementDto productMovementDto)
        {
            var productMovement = _mapper.Map<ProductMovement>(productMovementDto);
            await _productMovementService.InsertProductMovement(productMovement);
            productMovementDto = _mapper.Map<ProductMovementDto>(productMovement);
            return Ok(productMovementDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMovement(int id, ProductMovementDto productMovementDto)
        {
            var productMovement = _mapper.Map<ProductMovement>(productMovementDto);
            productMovement.Id = id;
            await _productMovementService.UpdateProductMovement(productMovement);
            productMovementDto = _mapper.Map<ProductMovementDto>(productMovement);
            return Ok(productMovementDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductMovement(int id)
        {
            var result = await _productMovementService.DeleteProductMovement(id);
            return Ok(result);
        }
    }
}
