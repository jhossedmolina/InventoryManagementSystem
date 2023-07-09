using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class StatusEmployedService : IStatusEmployedService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatusEmployedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public IEnumerable<StatusEmployed> GetAllStatusEmployees()
        {
            return _unitOfWork.StatusEmployedRepository.GetAll();
        }

        public async Task<StatusEmployed> GetStatusEmployedById(int id)
        {
            return await _unitOfWork.StatusEmployedRepository.GetById(id);
        }

        public async Task InsertStatusEmployed(StatusEmployed statusEmployed)
        {
            await _unitOfWork.StatusEmployedRepository.Add(statusEmployed);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateStatusEmployed(StatusEmployed statusEmployed)
        {
            var currentStatusEmployed = await _unitOfWork.StatusEmployedRepository.GetById(statusEmployed.Id);
            currentStatusEmployed.Code = statusEmployed.Code;
            currentStatusEmployed.Name = statusEmployed.Name;
            _unitOfWork.StatusEmployedRepository.Update(currentStatusEmployed);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStatusEmployed(int id)
        {
            await _unitOfWork.StatusEmployedRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
