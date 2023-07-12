using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;
        private readonly IMapper _mapper;

        public OrderStatusController(IOrderStatusService orderStatusService, IMapper mapper)
        {
            _orderStatusService = orderStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderStates()
        {
            var orderStates = _orderStatusService.GetAllOrderStates();
            var orderStatesDto = _mapper.Map<IEnumerable<OrderStatusDto>>(orderStates);
            return Ok(orderStatesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderStatus(int id)
        {
            var orderStatus = await _orderStatusService.GetOrderStatusById(id);
            var orderStatusDto = _mapper.Map<OrderStatusDto>(orderStatus);
            return Ok(orderStatusDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderStatus(OrderStatusDto orderStatusDto)
        {
            var orderStatus = _mapper.Map<OrderStatus>(orderStatusDto);
            await _orderStatusService.InsertOrderStatus(orderStatus);
            orderStatusDto = _mapper.Map<OrderStatusDto>(orderStatus);
            return Ok(orderStatusDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatusDto orderStatusDto)
        {
            var orderStatus = _mapper.Map<OrderStatus>(orderStatusDto);
            orderStatus.Id = id;
            await _orderStatusService.UpdateOrderStatus(orderStatus);
            orderStatusDto = _mapper.Map<OrderStatusDto>(orderStatus);
            return Ok(orderStatusDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatus(int id)
        {
            var result = await _orderStatusService.DeleteOrderStatus(id);
            return Ok(result);
        }
    }
}
