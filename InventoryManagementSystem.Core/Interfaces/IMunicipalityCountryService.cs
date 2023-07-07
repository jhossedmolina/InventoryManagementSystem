using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IMunicipalityCountryService
    {
        IEnumerable<MunicipalityCountry> GetAllMunicipalityCountries();
        Task<MunicipalityCountry> GetMunicipalityCountry(int id);
        Task InsertMunicipalityCountry(MunicipalityCountry country);
        Task<bool> UpdateMunicipalityCountry(MunicipalityCountry municipalityCountry);
        Task<bool> DeleteMunicipalityCountry(int id);
    }
}
