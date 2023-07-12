using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Client> ClientRepository { get; }
        IGenericRepository<DocumentType> DocumentTypeRepository { get; }
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<EmployeeUser> EmployeeUserRepository { get; }
        IGenericRepository<MunicipalityCountry> MunicipalityCountryRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<OrderHistory> OrderHistoryRepository { get; }
        IGenericRepository<OrderStatus> OrderStatusRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<ProductBrand> ProductBrandRepository { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        IGenericRepository<ProductHistory> ProductHistoryRepository { get; }
        IGenericRepository<ProductMovement> ProductMovementRepository { get; }
        IGenericRepository<ProductStock> ProductStockRepository { get; }
        IGenericRepository<RoleEmployee> RoleEmployeeRepository { get; }
        IGenericRepository<StateCountry> StateCountryRepository { get; }
        IGenericRepository<StatusEmployed> StatusEmployedRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
