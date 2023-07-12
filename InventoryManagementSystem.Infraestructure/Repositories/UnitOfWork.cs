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
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<OrderHistory> _orderHistoryRepository;
        private readonly IGenericRepository<OrderStatus> _orderStatusRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductHistory> _productHistoryRepository;
        private readonly IGenericRepository<ProductMovement> _productMovementRepository;
        private readonly IGenericRepository<ProductStock> _productStockRepository;
        private readonly IGenericRepository<RoleEmployee> _roleEmployee;
        private readonly IGenericRepository<StateCountry> _stateCountryRepository;
        private readonly IGenericRepository<StatusEmployed> _statusEmployedRepository;

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
        public IGenericRepository<OrderDetail> OrderDetailRepository => _orderDetailRepository ?? new GenericRepository<OrderDetail>(_context);
        public IGenericRepository<OrderHistory> OrderHistoryRepository => _orderHistoryRepository ?? new GenericRepository<OrderHistory>(_context);
        public IGenericRepository<OrderStatus> OrderStatusRepository => _orderStatusRepository ?? new GenericRepository<OrderStatus>(_context);
        public IGenericRepository<Product> ProductRepository => _productRepository ?? new GenericRepository<Product>(_context);
        public IGenericRepository<ProductBrand> ProductBrandRepository => _productBrandRepository ?? new GenericRepository<ProductBrand>(_context);
        public IGenericRepository<ProductCategory> ProductCategoryRepository => _productCategoryRepository ?? new GenericRepository<ProductCategory>(_context);
        public IGenericRepository<ProductHistory> ProductHistoryRepository => _productHistoryRepository ?? new GenericRepository<ProductHistory>(_context);
        public IGenericRepository<ProductMovement> ProductMovementRepository => _productMovementRepository ?? new GenericRepository<ProductMovement>(_context);
        public IGenericRepository<ProductStock> ProductStockRepository => _productStockRepository ?? new GenericRepository<ProductStock>(_context);
        public IGenericRepository<RoleEmployee> RoleEmployeeRepository => _roleEmployee ?? new GenericRepository<RoleEmployee>(_context);
        public IGenericRepository<StateCountry> StateCountryRepository => _stateCountryRepository ?? new GenericRepository<StateCountry>(_context);
        public IGenericRepository<StatusEmployed> StatusEmployedRepository => _statusEmployedRepository ?? new GenericRepository<StatusEmployed>(_context);

        

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
