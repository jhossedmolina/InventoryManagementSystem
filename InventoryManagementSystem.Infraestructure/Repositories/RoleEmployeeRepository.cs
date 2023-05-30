using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class RoleEmployeeRepository : IRoleEmployeeRepository
    {
        private readonly InventoryManagerSystemDbContext _context;

        public RoleEmployeeRepository(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleEmployee>> GetRoleEmployees()
        {
            var roleEmployees = await _context.RoleEmployees.ToListAsync();
            return roleEmployees;
        }

        public async Task<RoleEmployee> GetRoleEmployee(int id)
        {
            var roleEmployee = await _context.RoleEmployees.FindAsync(id);
            return roleEmployee;
        }

        public async Task InsertRoleEmployee(RoleEmployee roleEmployee)
        {
            _context.RoleEmployees.Add(roleEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRoleEmployee(RoleEmployee roleEmployee)
        {
            var currentRoleEmployee = await GetRoleEmployee(roleEmployee.Id);
            currentRoleEmployee.Code = roleEmployee.Code;
            currentRoleEmployee.Name = roleEmployee.Name;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteRoleEmployee(int id)
        {
            var currentRoleEmployee = await GetRoleEmployee(id);
            _context.RoleEmployees.Remove(currentRoleEmployee);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
