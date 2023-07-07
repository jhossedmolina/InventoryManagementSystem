using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductBrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductBrand> GetAllProductBrands()
        {
            return _unitOfWork.ProductBrandRepository.GetAll();
        }

        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            return await _unitOfWork.ProductBrandRepository.GetById(id);
        }

        public async Task InsertProductBrand(ProductBrand productBrand)
        {
            await _unitOfWork.ProductBrandRepository.Add(productBrand);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductBrand(ProductBrand productBrand)
        {
            var existingProductBrand = await _unitOfWork.ProductBrandRepository.GetById(productBrand.Id);
            existingProductBrand.Name = productBrand.Name;
            existingProductBrand.IdProductCategory = productBrand.IdProductCategory;
            _unitOfWork.ProductBrandRepository.Update(existingProductBrand);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductBrand(int id)
        {
            await _unitOfWork.ProductBrandRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
