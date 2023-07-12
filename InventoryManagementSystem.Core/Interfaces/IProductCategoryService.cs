using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
        Task<ProductCategory> GetProductCategoryById(int id);
        Task InsertProductCategory(ProductCategory productCategory);
        Task<bool> UpdateProductCategory(ProductCategory productCategory);
        Task<bool> DeleteProductCategory(int id);
    }
}
