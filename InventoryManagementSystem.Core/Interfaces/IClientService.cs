using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Task<Client> GetClientById(int id);
        Task InsertClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}
