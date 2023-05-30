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
        private readonly IRoleEmployeeRepository _roleEmployeeRepository;
        private readonly IMapper _mapper;

        public RoleEmployeeController(IRoleEmployeeRepository roleEmployeeRepository, IMapper mapper)
        {
            _roleEmployeeRepository = roleEmployeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleEmployees()
        {
            var roleEmployees = await _roleEmployeeRepository.GetRoleEmployees();
            var roleEmployeesDto = _mapper.Map<IEnumerable<RoleEmployeeDto>>(roleEmployees);
            return Ok(roleEmployeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleEmployee(int id)
        {
            var roleEmployee = await _roleEmployeeRepository.GetRoleEmployee(id);
            var roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoleEmployee(RoleEmployeeDto roleEmployeeDto)
        {
            var roleEmployee = _mapper.Map<RoleEmployee>(roleEmployeeDto);
            await _roleEmployeeRepository.InsertRoleEmployee(roleEmployee);
            roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleEmployee(int id, RoleEmployeeDto roleEmployeeDto)
        {
            var roleEmployee = _mapper.Map<RoleEmployee>(roleEmployeeDto);
            roleEmployee.Id = id;
            await _roleEmployeeRepository.UpdateRoleEmployee(roleEmployee);
            roleEmployeeDto = _mapper.Map<RoleEmployeeDto>(roleEmployee);
            return Ok(roleEmployeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleEmployee(int id)
        {
            var result = await _roleEmployeeRepository.DeleteRoleEmployee(id);
            return Ok(result);
        }
    }
}
