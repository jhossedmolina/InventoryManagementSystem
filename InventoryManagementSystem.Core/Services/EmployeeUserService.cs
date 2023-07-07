using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class EmployeeUserService : IEmployeeUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeUser> GetAllEmnployeeUsers()
        {
            return _unitOfWork.EmployeeUserRepository.GetAll();
        }

        public async Task<EmployeeUser> GetEmployeeUserById(int id)
        {
            return await _unitOfWork.EmployeeUserRepository.GetById(id);
        }

        public async Task InsertEmployeeUser(EmployeeUser employeeUser)
        {
            await _unitOfWork.EmployeeUserRepository.Add(employeeUser);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployeeUSer(EmployeeUser employeeUser)
        {
            var existingEmployeeUser = await _unitOfWork.EmployeeUserRepository.GetById(employeeUser.Id);
            existingEmployeeUser.Username = employeeUser.Username;
            existingEmployeeUser.Password = employeeUser.Password;
            existingEmployeeUser.IdEmployee = employeeUser.IdEmployee;
            existingEmployeeUser.IdRoleEmployee = employeeUser.IdRoleEmployee;
            existingEmployeeUser.IdStatusEmployed = employeeUser.IdStatusEmployed;
            _unitOfWork.EmployeeUserRepository.Update(existingEmployeeUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeUser(int id)
        {
            await _unitOfWork.EmployeeUserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
