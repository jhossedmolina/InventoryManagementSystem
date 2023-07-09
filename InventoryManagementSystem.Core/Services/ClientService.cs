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
            var currentClient = await _unitOfWork.ClientRepository.GetById(client.Id);
            currentClient.DocNumber = client.DocNumber;
            currentClient.IdDocumentType = client.IdDocumentType;
            currentClient.FirstName = client.FirstName;
            currentClient.LastName = client.LastName;
            currentClient.ContactNumber = client.ContactNumber;
            currentClient.Address = client.Address;
            currentClient.IdMunicipalityCountry = client.IdMunicipalityCountry;
            _unitOfWork.ClientRepository.Update(currentClient);
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
