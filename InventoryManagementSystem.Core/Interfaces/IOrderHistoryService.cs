using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IOrderHistoryService
    {
        IEnumerable<OrderHistory> GetAllOrderHistory();
        Task<OrderHistory> GetOrderHistoryById(int id);
        Task InsertOrderHistory(OrderHistory orderHistory);
        Task<bool> UpdateOrderHistory(OrderHistory orderHistory);
        Task<bool> DeleteOrderHistory(int id);
    }
}
