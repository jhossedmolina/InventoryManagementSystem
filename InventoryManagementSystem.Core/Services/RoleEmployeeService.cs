using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class RoleEmployeeService : IRoleEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleEmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RoleEmployee> GetAllRoleEmployees()
        {
            return _unitOfWork.RoleEmployeeRepository.GetAll();
        }

        public Task<RoleEmployee> GetRoleEmployeeById(int id)
        {
            return _unitOfWork.RoleEmployeeRepository.GetById(id);
        }

        public async Task InsertRoleEmployee(RoleEmployee roleEmployee)
        {
            await _unitOfWork.RoleEmployeeRepository.Add(roleEmployee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateRoleEmployee(RoleEmployee roleEmployee)
        {
            var existingRoleEmployee = await _unitOfWork.RoleEmployeeRepository.GetById(roleEmployee.Id);
            existingRoleEmployee.Code = roleEmployee.Code;
            existingRoleEmployee.Name = roleEmployee.Name;
            _unitOfWork.RoleEmployeeRepository.Update(existingRoleEmployee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoleEmployee(int id)
        {
            await _unitOfWork.RoleEmployeeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
