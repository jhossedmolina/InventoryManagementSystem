using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductHistoryService
    {
        IEnumerable<ProductHistory> GetProductHistory();
        Task<ProductHistory> GetProductHistory(int id);
        Task InsertProductHistory(ProductHistory productHistory);
        Task<bool> UpdateProductHistory(ProductHistory productHistory);
        Task<bool> DeleteProductHistory(int id);
    }
}
