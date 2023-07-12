using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductHistoryService : IProductHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductHistory> GetProductHistory()
        {
            return _unitOfWork.ProductHistoryRepository.GetAll();
        }

        public async Task<ProductHistory> GetProductHistory(int id)
        {
            return await _unitOfWork.ProductHistoryRepository.GetById(id);
        }

        public async Task InsertProductHistory(ProductHistory productHistory)
        {
            await _unitOfWork.ProductHistoryRepository.Add(productHistory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductHistory(ProductHistory productHistory)
        {
            var currentProductHistory = await _unitOfWork.ProductHistoryRepository.GetById(productHistory.Id);
            currentProductHistory.QuantityProduct = productHistory.QuantityProduct;
            currentProductHistory.IdProductMovement = productHistory.IdProductMovement;
            currentProductHistory.UpdateDate = productHistory.UpdateDate;
            currentProductHistory.IdProductStock = productHistory.IdProductStock;
            currentProductHistory.IdOrderDetail = productHistory.IdOrderDetail;
            _unitOfWork.ProductHistoryRepository.Update(currentProductHistory);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductHistory(int id)
        {
            await _unitOfWork.ProductHistoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
