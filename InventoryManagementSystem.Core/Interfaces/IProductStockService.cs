using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductStockService
    {
        IEnumerable<ProductStock> GetAllProductStocks();
        Task<ProductStock> GetProductStock(int id);
        Task InsertProductStock(ProductStock productStock);
        Task<bool> UpdateProductStock(ProductStock productStock);
        Task<bool> DeleteProductStock(int id);
    }
}
