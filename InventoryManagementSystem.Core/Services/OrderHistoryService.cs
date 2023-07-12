using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderHistory> GetAllOrderHistory()
        {
            return _unitOfWork.OrderHistoryRepository.GetAll();
        }

        public async Task<OrderHistory> GetOrderHistoryById(int id)
        {
            return await _unitOfWork.OrderHistoryRepository.GetById(id);
        }

        public async Task InsertOrderHistory(OrderHistory orderHistory)
        {
            await _unitOfWork.OrderHistoryRepository.Add(orderHistory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrderHistory(OrderHistory orderHistory)
        {
            var currentOrderHistory = await _unitOfWork.OrderHistoryRepository.GetById(orderHistory.Id);
            currentOrderHistory.IdOrder = orderHistory.IdOrder;
            currentOrderHistory.IdOrderSatus = orderHistory.IdOrderSatus;
            currentOrderHistory.UpdateDate = orderHistory.UpdateDate;
            currentOrderHistory.IdOrderDetail = orderHistory.IdOrderDetail;
            _unitOfWork.OrderHistoryRepository.Update(currentOrderHistory);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrderHistory(int id)
        {
            await _unitOfWork.OrderHistoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync(); 
            return true;
        }
    }
}
