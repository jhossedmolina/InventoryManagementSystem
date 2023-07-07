using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            return _unitOfWork.EmployeeRepository.GetById(id);
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _unitOfWork.EmployeeRepository.Add(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _unitOfWork.EmployeeRepository.GetById(employee.Id);
            existingEmployee.DocNumber = employee.DocNumber;
            existingEmployee.IdDocumentType = employee.IdDocumentType;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.ContactNumber = employee.ContactNumber;
            existingEmployee.Email = employee.Email;
            _unitOfWork.EmployeeRepository.Update(existingEmployee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            await _unitOfWork.EmployeeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
