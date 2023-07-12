using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductMovementService
    {
        IEnumerable<ProductMovement> GetProductMovements();
        Task<ProductMovement> GetProductMovement(int id);
        Task InsertProductMovement(ProductMovement productMovement);
        Task<bool> UpdateProductMovement(ProductMovement productMovement);
        Task<bool> DeleteProductMovement(int id);
    }
}
