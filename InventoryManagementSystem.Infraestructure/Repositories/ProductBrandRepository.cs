using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly InventoryManagerSystemDbContext _context;

        public ProductBrandRepository(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _context.ProductBrands.ToListAsync();
            return productBrands;
        }

        public async Task<ProductBrand> GetProductBrand(int id)
        {
            var productBrand = await _context.ProductBrands.FindAsync(id);
            return productBrand;
        }

        public async Task InsertProductBrand(ProductBrand productBrand)
        {
            _context.ProductBrands.Add(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProuctBrand(ProductBrand productBrand)
        {
            var currentProductBrand = await GetProductBrand(productBrand.Id);
            currentProductBrand.Name = productBrand.Name;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteProductBrand(int id)
        {
            var currentProductBrand = await GetProductBrand(id);
            _context.ProductBrands.Remove(currentProductBrand);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
