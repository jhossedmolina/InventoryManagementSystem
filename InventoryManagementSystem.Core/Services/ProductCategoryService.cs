using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return _unitOfWork.ProductCategoryRepository.GetAll();
        }

        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            return await _unitOfWork.ProductCategoryRepository.GetById(id);
        }

        public async Task InsertProductCategory(ProductCategory productCategory)
        {
            await _unitOfWork.ProductCategoryRepository.Add(productCategory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductCategory(ProductCategory productCategory)
        {
            var currentProductCategory = await _unitOfWork.ProductCategoryRepository.GetById(productCategory.Id);
            currentProductCategory.Code = productCategory.Code;
            currentProductCategory.Name = productCategory.Name;
            _unitOfWork.ProductCategoryRepository.Update(currentProductCategory);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductCategory(int id)
        {
            await _unitOfWork.ProductCategoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
