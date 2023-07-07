using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleEmployeeController : ControllerBase
    {
        private readonly IRoleEmployeeService _roleEmployeeService;
        private readonly IMapper _mapper;

        public RoleEmployeeController(IRoleEmployeeService roleEmployeeService, IMapper mapper)
        {
            _roleEmployeeService = roleEmployeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleEmployees()
        {
            var roleEmployees = _roleEmployeeService.GetAllRoleEmployees();
            var roleEmployeesDto = _mapper.Map<IEnumerable<RoleEmployeeDto>>(roleEmployees);
            return Ok(roleEmployeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleEmployee(int id)
        {
            var roleEmployee = await _roleEmployeeService.GetRoleEmployeeById(id);
            var roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoleEmployee(RoleEmployeeDto roleEmployeeDto)
        {
            var roleEmployee = _mapper.Map<RoleEmployee>(roleEmployeeDto);
            await _roleEmployeeService.InsertRoleEmployee(roleEmployee);
            roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleEmployee(int id, RoleEmployeeDto roleEmployeeDto)
        {
            var roleEmployee = _mapper.Map<RoleEmployee>(roleEmployeeDto);
            roleEmployee.Id = id;
            await _roleEmployeeService.UpdateRoleEmployee(roleEmployee);
            roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleEmployee(int id)
        {
            var result = await _roleEmployeeService.DeleteRoleEmployee(id);
            return Ok(result);
        }
    }
}
