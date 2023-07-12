using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductStockService : IProductStockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductStockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public IEnumerable<ProductStock> GetAllProductStocks()
        {
            return _unitOfWork.ProductStockRepository.GetAll();
        }

        public async Task<ProductStock> GetProductStock(int id)
        {
            return await _unitOfWork.ProductStockRepository.GetById(id);
        }

        public async Task InsertProductStock(ProductStock productStock)
        {
            await _unitOfWork.ProductStockRepository.Add(productStock);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductStock(ProductStock productStock)
        {
            var currentProductStock = await _unitOfWork.ProductStockRepository.GetById(productStock.Id);
            currentProductStock.QuantityProduct = productStock.QuantityProduct;
            currentProductStock.IdProduct = productStock.IdProduct;
            _unitOfWork.ProductStockRepository.Update(currentProductStock);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductStock(int id)
        {
            await _unitOfWork.ProductStockRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
