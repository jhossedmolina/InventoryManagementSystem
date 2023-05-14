using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetProductBrands();
        Task<ProductBrand> GetProductBrand(int id);
        Task InsertProductBrand(ProductBrand productBrand);
        Task<bool> UpdateProuctBrand(ProductBrand productBrand);
        Task<bool> DeleteProductBrand(int id);
    }
}
