using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IEmployeeUserService
    {
        IEnumerable<EmployeeUser> GetAllEmnployeeUsers();
        Task<EmployeeUser> GetEmployeeUserById(int id);
        Task InsertEmployeeUser(EmployeeUser employeeUser);
        Task<bool> UpdateEmployeeUSer(EmployeeUser employeeUser);
        Task<bool> DeleteEmployeeUser(int id);
    }
}
