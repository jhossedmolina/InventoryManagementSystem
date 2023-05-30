using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class MunicipalityCountryRepository : IMunicipalityCountryRepository
    {
        private readonly InventoryManagerSystemDbContext _context;

        public MunicipalityCountryRepository(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MunicipalityCountry>> GetMunicipalitiesCountry()
        {
            var municipalitiesCountry = await _context.MunicipalityCountries.ToListAsync();
            return municipalitiesCountry;
        }

        public async Task<MunicipalityCountry> GetMunicipalityCountry(int id)
        {
            var municipalityCountry = await _context.MunicipalityCountries.FindAsync(id);
            return municipalityCountry;
        }

        public async Task InsertMunicipalityCountry(MunicipalityCountry municipalityCountry)
        {
            _context.MunicipalityCountries.Add(municipalityCountry);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateMunicipalityCountry(MunicipalityCountry municipalityCountry)
        {
            var currentMunicipalityCountry = await GetMunicipalityCountry(municipalityCountry.Id);
            currentMunicipalityCountry.Code = municipalityCountry.Code;
            currentMunicipalityCountry.Name = municipalityCountry.Name;
            currentMunicipalityCountry.IdStateCountry = municipalityCountry.IdStateCountry;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteMunicipalityCountry(int id)
        {
            var currentMunicipalityCountry = await GetMunicipalityCountry(id);
            _context.MunicipalityCountries.Remove(currentMunicipalityCountry);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
