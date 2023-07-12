using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
