namespace InventoryManagementSystem.Core.entities;

public partial class ProductBrand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
