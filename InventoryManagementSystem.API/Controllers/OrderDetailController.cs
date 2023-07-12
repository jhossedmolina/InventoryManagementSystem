using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
            return Ok(orderDetailsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(id);
            var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
            return Ok(orderDetailDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrderDetail(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _orderDetailService.InsertOrderDetail(orderDetail);
            orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
            return Ok(orderDetailDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            orderDetail.Id = id;
            await _orderDetailService.UpdateOrderDetail(orderDetail);
            orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
            return Ok(orderDetailDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var result = await _orderDetailService.DeleteOrderDetail(id);
            return Ok(result);
        }
    }
}
