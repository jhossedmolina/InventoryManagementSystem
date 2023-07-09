using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _unitOfWork.OrderRepository.GetAll();
        }

        public Task<Order> GetOrderById(int id)
        {
            return _unitOfWork.OrderRepository.GetById(id);
        }

        public async Task InsertOrder(Order order)
        {
            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var currentOrder = await _unitOfWork.OrderRepository.GetById(order.Id);
            currentOrder.IdClient = order.IdClient;
            currentOrder.OrderDate = order.OrderDate;
            currentOrder.OrderDeliveryDate = order.OrderDeliveryDate;
            currentOrder.Description = order.Description;
            currentOrder.IdOrderStatus = order.IdOrderStatus;
            _unitOfWork.OrderRepository.Update(currentOrder);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await _unitOfWork.OrderRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
