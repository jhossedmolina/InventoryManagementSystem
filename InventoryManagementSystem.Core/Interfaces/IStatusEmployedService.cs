using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IStatusEmployedService
    {
        IEnumerable<StatusEmployed> GetAllStatusEmployees();
        Task<StatusEmployed> GetStatusEmployedById(int id);
        Task InsertStatusEmployed(StatusEmployed statusEmployed);
        Task<bool> UpdateStatusEmployed(StatusEmployed statusEmployed);
        Task<bool> DeleteStatusEmployed(int id);
    }
}
