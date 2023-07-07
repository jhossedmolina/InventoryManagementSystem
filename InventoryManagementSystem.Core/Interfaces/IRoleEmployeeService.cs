using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IRoleEmployeeService
    {
        IEnumerable<RoleEmployee> GetAllRoleEmployees();
        Task<RoleEmployee> GetRoleEmployeeById(int id);
        Task InsertRoleEmployee(RoleEmployee roleEmployee);
        Task<bool> UpdateRoleEmployee(RoleEmployee roleEmployee);
        Task<bool> DeleteRoleEmployee(int id);
    }
}
