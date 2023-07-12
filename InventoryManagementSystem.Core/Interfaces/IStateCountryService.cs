using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IStateCountryService
    {
        IEnumerable<StateCountry> GetAllStateCountries();
        Task<StateCountry> GetStateCountry(int id);
        Task InsertStateCountry(StateCountry stateCountry);
        Task<bool> UpdateStateCountry(StateCountry stateCountry);
        Task<bool> DeleteStateCountry(int id);
    }
}
