using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryManagerSystemDbContext _context;
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IGenericRepository<DocumentType> _documentTypeRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<EmployeeUser> _employeeUserRepository;
        private readonly IGenericRepository<MunicipalityCountry> _municipalityCountryRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<RoleEmployee> _roleEmployee;
        

        public UnitOfWork(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Client> ClientRepository => _clientRepository ?? new GenericRepository<Client>(_context);
        public IGenericRepository<DocumentType> DocumentTypeRepository => _documentTypeRepository ?? new GenericRepository<DocumentType>(_context);
        public IGenericRepository<Employee> EmployeeRepository => _employeeRepository ?? new GenericRepository<Employee>(_context);
        public IGenericRepository<EmployeeUser> EmployeeUserRepository => _employeeUserRepository ?? new GenericRepository<EmployeeUser>(_context);
        public IGenericRepository<MunicipalityCountry> MunicipalityCountryRepository => _municipalityCountryRepository ?? new GenericRepository<MunicipalityCountry>(_context);
        public IGenericRepository<Order> OrderRepository => _orderRepository ?? new GenericRepository<Order>(_context);
        public IGenericRepository<ProductBrand> ProductBrandRepository => _productBrandRepository ?? new GenericRepository<ProductBrand>(_context);
        public IGenericRepository<RoleEmployee> RoleEmployeeRepository => _roleEmployee ?? new GenericRepository<RoleEmployee>(_context);

        


        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
