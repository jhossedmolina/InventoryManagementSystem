using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeUserController : ControllerBase
    {
        private readonly IEmployeeUserService _employeeUserService;
        private readonly IMapper _mapper;

        public EmployeeUserController(IEmployeeUserService employeeUserService, IMapper mapper)
        {
            _employeeUserService = employeeUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeUsers()
        {
            var employeeUsers = _employeeUserService.GetAllEmnployeeUsers();
            var employeeUsersDto = _mapper.Map<IEnumerable<EmployeeUser>>(employeeUsers);
            return Ok(employeeUsersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeUser(int id)
        {
            var employeeUser = await _employeeUserService.GetEmployeeUserById(id);
            var employeeUserDto = _mapper.Map<EmployeeDto>(employeeUser);
            return Ok(employeeUserDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployeeUser(EmployeeUserDto employeeUserDto)
        {
            var employeeUser = _mapper.Map<EmployeeUser>(employeeUserDto);
            await _employeeUserService.InsertEmployeeUser(employeeUser);
            employeeUserDto = _mapper.Map<EmployeeUserDto>(employeeUser);
            return Ok(employeeUserDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeUser(int id, EmployeeUserDto employeeUserDto)
        {
            var employeeUser = _mapper.Map<EmployeeUser>(employeeUserDto);
            employeeUser.Id = id;
            await _employeeUserService.UpdateEmployeeUSer(employeeUser);
            employeeUserDto = _mapper.Map<EmployeeUserDto>(employeeUser);
            return Ok(employeeUserDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeUser(int id)
        {
            var result = await _employeeUserService.DeleteEmployeeUser(id);
            return Ok(result);
        }
    }
}
