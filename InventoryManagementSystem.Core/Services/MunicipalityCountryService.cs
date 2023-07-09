using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class MunicipalityCountryService : IMunicipalityCountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MunicipalityCountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MunicipalityCountry> GetAllMunicipalityCountries()
        {
            return _unitOfWork.MunicipalityCountryRepository.GetAll();
        }

        public async Task<MunicipalityCountry> GetMunicipalityCountry(int id)
        {
            return await _unitOfWork.MunicipalityCountryRepository.GetById(id);
        }

        public async Task InsertMunicipalityCountry(MunicipalityCountry country)
        {
            await _unitOfWork.MunicipalityCountryRepository.Add(country);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMunicipalityCountry(MunicipalityCountry municipalityCountry)
        {
            var currentMunicipalityCountry = await _unitOfWork.MunicipalityCountryRepository.GetById(municipalityCountry.Id);
            currentMunicipalityCountry.Code = municipalityCountry.Code;
            currentMunicipalityCountry.Name = municipalityCountry.Name;
            currentMunicipalityCountry.IdStateCountry = municipalityCountry.IdStateCountry;
            _unitOfWork.MunicipalityCountryRepository.Update(currentMunicipalityCountry);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMunicipalityCountry(int id)
        {
            await _unitOfWork.MunicipalityCountryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
