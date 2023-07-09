using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _unitOfWork.OrderDetailRepository.GetAll();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _unitOfWork.OrderDetailRepository.GetById(id);
        }

        public async Task InsertOrderDetail(OrderDetail orderDetail)
        {
            await _unitOfWork.OrderDetailRepository.Add(orderDetail);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var currentOrderDetail = await _unitOfWork.OrderDetailRepository.GetById(orderDetail.Id);
            currentOrderDetail.UpdateDate = orderDetail.UpdateDate;
            currentOrderDetail.IdOrder = orderDetail.IdOrder;
            currentOrderDetail.Observations = orderDetail.Observations;
            currentOrderDetail.IdProductHistory = orderDetail.IdProductHistory;
            currentOrderDetail.QuantityProduct = orderDetail.QuantityProduct;
            _unitOfWork.OrderDetailRepository.Update(currentOrderDetail);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderDetail(int id)
        {
            await _unitOfWork.OrderDetailRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
