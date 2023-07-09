using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = _orderService.GetAllOrders();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrders(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderService.InsertOrder(order);
            orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Id = id;
            await _orderService.UpdateOrder(order);
            orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            return Ok(result);
        }
    }
}
