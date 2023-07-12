using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly IMapper _mapper;

        public OrderHistoryController(IOrderHistoryService orderHistoryService, Mapper mapper)
        {
            _orderHistoryService = orderHistoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderHistory()
        {
            var orderHistory = _orderHistoryService.GetAllOrderHistory();
            var orderHistoryDto = _mapper.Map<IEnumerable<OrderHistoryDto>>(orderHistory);
            return Ok(orderHistoryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderHistory(int id)
        {
            var orderHistory = await _orderHistoryService.GetOrderHistoryById(id);
            var orderHistoryDto = _mapper.Map<OrderHistoryDto>(orderHistory);
            return Ok(orderHistoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderHistory(OrderHistoryDto orderHistoryDto)
        {
            var orderHistory = _mapper.Map<OrderHistory>(orderHistoryDto);
            await _orderHistoryService.InsertOrderHistory(orderHistory);
            orderHistoryDto = _mapper.Map<OrderHistoryDto>(orderHistory);
            return Ok(orderHistoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderHistory(int id, OrderHistoryDto orderHistoryDto)
        {
            var orderHistory = _mapper.Map<OrderHistory>(orderHistoryDto);
            orderHistory.Id = id;
            await _orderHistoryService.UpdateOrderHistory(orderHistory);
            orderHistoryDto = _mapper.Map<OrderHistoryDto>(orderHistory);
            return Ok(orderHistoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHistory(int id)
        {
            var result = await _orderHistoryService.DeleteOrderHistory(id);
            return Ok(result);
        }
    }
}
