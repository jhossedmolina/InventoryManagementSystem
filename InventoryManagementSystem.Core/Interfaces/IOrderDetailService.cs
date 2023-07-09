using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int id);
        Task InsertOrderDetail(OrderDetail orderDetail);
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetail(int id);
    }
}
