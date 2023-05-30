using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly InventoryManagerSystemDbContext _context;

        public ClientRepository(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            return client;
        }

        public async Task InsertClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var currentClient = await GetClient(client.Id);
            currentClient.DocNumber = client.DocNumber;
            currentClient.IdDocumentType = client.IdDocumentType;
            currentClient.FirstName = client.FirstName;
            currentClient.LastName = client.LastName;
            currentClient.ContactNumber = client.ContactNumber;
            currentClient.Address = client.Address;
            currentClient.IdMunicipalityCountry = client.IdMunicipalityCountry;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var currentClient = await GetClient(id);
            _context.Clients.Remove(currentClient);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
