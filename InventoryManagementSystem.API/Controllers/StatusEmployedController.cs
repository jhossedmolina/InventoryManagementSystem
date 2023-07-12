using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusEmployedController : ControllerBase
    {
        private readonly IStatusEmployedService _statusEmployedService;
        private readonly IMapper _mapper;

        public StatusEmployedController(IStatusEmployedService statusEmployedService, IMapper mapper)
        {
            _statusEmployedService = statusEmployedService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusEmployees()
        {
            var statusEmployees = _statusEmployedService.GetAllStatusEmployees();
            var statusEmployeesDto = _mapper.Map<IEnumerable<StatusEmployedDto>>(statusEmployees);
            return Ok(statusEmployeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusEmployed(int id)
        {
            var statusEmployed = await _statusEmployedService.GetStatusEmployedById(id);
            var statusEmployedDto = _mapper.Map<StatusEmployedDto>(statusEmployed);
            return Ok(statusEmployedDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostStatusEmployed(StatusEmployedDto statusEmployedDto)
        {
            var statusEmployed = _mapper.Map<StatusEmployed>(statusEmployedDto);
            await _statusEmployedService.InsertStatusEmployed(statusEmployed);
            statusEmployedDto = _mapper.Map<StatusEmployedDto>(statusEmployed);
            return Ok(statusEmployedDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusEmployed(int id, StatusEmployedDto statusEmployedDto)
        {
            var statusEmployed = _mapper.Map<StatusEmployed>(statusEmployedDto);
            statusEmployed.Id = id;
            await _statusEmployedService.UpdateStatusEmployed(statusEmployed);
            statusEmployedDto = _mapper.Map<StatusEmployedDto>(statusEmployed);
            return Ok(statusEmployedDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStatusEmployees(int id)
        {
            var result = await _statusEmployedService.DeleteStatusEmployed(id);
            return Ok(result);
        }
    }
}
