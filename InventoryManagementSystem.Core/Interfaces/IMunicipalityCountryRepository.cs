using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IMunicipalityCountryRepository
    {
        Task<IEnumerable<MunicipalityCountry>> GetMunicipalitiesCountry();
        Task<MunicipalityCountry> GetMunicipalityCountry(int id);
        Task InsertMunicipalityCountry(MunicipalityCountry municipalityCountry);
        Task<bool> UpdateMunicipalityCountry(MunicipalityCountry municipalityCountry);
        Task<bool> DeleteMunicipalityCountry(int id);
    }
}
