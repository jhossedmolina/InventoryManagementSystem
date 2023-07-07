using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductBrandService
    {
        IEnumerable<ProductBrand> GetAllProductBrands();
        Task<ProductBrand> GetProductBrandById(int id);
        Task InsertProductBrand(ProductBrand productBrand);
        Task<bool> UpdateProductBrand(ProductBrand productBrand);
        Task<bool> DeleteProductBrand(int id);
    }
}
