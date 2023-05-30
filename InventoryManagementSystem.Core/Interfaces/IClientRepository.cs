using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task InsertClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}
