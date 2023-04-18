namespace InventoryManagementSystem.Core.Entities;

public partial class BrandProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
