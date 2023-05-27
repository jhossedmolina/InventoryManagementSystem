using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly InventoryManagerContext _context;

        public EmployeeRepository(InventoryManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employess = await _context.Employees.ToListAsync();
            return employess;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var currentEmployee = await GetEmployee(employee.Id);
            currentEmployee.DocNumber = employee.DocNumber;
            currentEmployee.IdDocumentType = employee.IdDocumentType;
            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;
            currentEmployee.ContactNumber = employee.ContactNumber;
            currentEmployee.Email = employee.Email;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var currentEmployee = await GetEmployee(id);
            _context.Employees.Remove(currentEmployee);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
