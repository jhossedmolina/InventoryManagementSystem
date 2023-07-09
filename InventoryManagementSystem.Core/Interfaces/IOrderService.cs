using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task InsertOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
