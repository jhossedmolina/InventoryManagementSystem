using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _unitOfWork.ClientRepository.GetAll();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _unitOfWork.ClientRepository.GetById(id);
        }

        public async Task InsertClient(Client client)
        {
            await _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var existingClient = await _unitOfWork.ClientRepository.GetById(client.Id);
            existingClient.DocNumber = client.DocNumber;
            existingClient.IdDocumentType = client.IdDocumentType;
            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.ContactNumber = client.ContactNumber;
            existingClient.Address = client.Address;
            existingClient.IdMunicipalityCountry = client.IdMunicipalityCountry;
            _unitOfWork.ClientRepository.Update(existingClient);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            await _unitOfWork.ClientRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
