using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderStatus> GetAllOrderStates()
        {
            return _unitOfWork.OrderStatusRepository.GetAll();
        }

        public async Task<OrderStatus> GetOrderStatusById(int id)
        {
            return await _unitOfWork.OrderStatusRepository.GetById(id);
        }

        public async Task InsertOrderStatus(OrderStatus orderStatus)
        {
            await _unitOfWork.OrderStatusRepository.Add(orderStatus);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrderStatus(OrderStatus orderStatus)
        {
            var currentOrderStatus = await _unitOfWork.OrderStatusRepository.GetById(orderStatus.Id);
            currentOrderStatus.Code = orderStatus.Code;
            currentOrderStatus.Name = orderStatus.Name;
            _unitOfWork.OrderStatusRepository.Update(currentOrderStatus);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderStatus(int id)
        {
            await _unitOfWork.OrderStatusRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
