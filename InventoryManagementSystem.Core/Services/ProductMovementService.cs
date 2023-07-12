using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductMovementService : IProductMovementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductMovementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductMovement> GetProductMovements()
        {
            return _unitOfWork.ProductMovementRepository.GetAll();
        }

        public async Task<ProductMovement> GetProductMovement(int id)
        {
            return await _unitOfWork.ProductMovementRepository.GetById(id);
        }

        public async Task InsertProductMovement(ProductMovement productMovement)
        {
            await _unitOfWork.ProductMovementRepository.Add(productMovement);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductMovement(ProductMovement productMovement)
        {
            var currentProductMovement = await _unitOfWork.ProductMovementRepository.GetById(productMovement.Id);
            currentProductMovement.Code = productMovement.Code;
            currentProductMovement.Name = productMovement.Name;
            _unitOfWork.ProductMovementRepository.Update(currentProductMovement);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductMovement(int id)
        {
            await _unitOfWork.ProductMovementRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
