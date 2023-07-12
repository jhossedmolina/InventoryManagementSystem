using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task InsertProduct(Product product)
        {
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var currentProduct = await _unitOfWork.ProductRepository.GetById(product.Id);
            currentProduct.Name = product.Name;
            currentProduct.Description = product.Description;
            currentProduct.IdProductCategory = product.IdProductCategory;
            _unitOfWork.ProductRepository.Update(currentProduct);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
