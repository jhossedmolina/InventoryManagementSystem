using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatus> GetAllOrderStates();
        Task<OrderStatus> GetOrderStatusById(int id);
        Task InsertOrderStatus(OrderStatus orderStatus);
        Task<bool> UpdateOrderStatus(OrderStatus orderStatus);
        Task<bool> DeleteOrderStatus(int id);
    }
}
