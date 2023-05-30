using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IRoleEmployeeRepository
    {
        Task<IEnumerable<RoleEmployee>> GetRoleEmployees();
        Task<RoleEmployee> GetRoleEmployee(int id);
        Task InsertRoleEmployee(RoleEmployee roleEmployee);
        Task<bool> UpdateRoleEmployee(RoleEmployee roleEmployee);
        Task<bool> DeleteRoleEmployee(int id);
    }
}
