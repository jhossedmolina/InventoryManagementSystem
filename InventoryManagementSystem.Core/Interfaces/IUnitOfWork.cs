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
        IGenericRepository <Order> OrderRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
