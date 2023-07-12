using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class StateCountryService : IStateCountryService
    {
        private IUnitOfWork _unitOfWork;

        public StateCountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StateCountry> GetAllStateCountries()
        {
            return _unitOfWork.StateCountryRepository.GetAll();
        }

        public async Task<StateCountry> GetStateCountry(int id)
        {
            return await _unitOfWork.StateCountryRepository.GetById(id);
        }

        public async Task InsertStateCountry(StateCountry stateCountry)
        {
            await _unitOfWork.StateCountryRepository.Add(stateCountry);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateStateCountry(StateCountry stateCountry)
        {
            var currentStateCountry = await _unitOfWork.StateCountryRepository.GetById(stateCountry.Id);
            currentStateCountry.Code = stateCountry.Code;
            currentStateCountry.Name = stateCountry.Name;
            _unitOfWork.StateCountryRepository.Update(currentStateCountry);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStateCountry(int id)
        {
            await _unitOfWork.StateCountryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
