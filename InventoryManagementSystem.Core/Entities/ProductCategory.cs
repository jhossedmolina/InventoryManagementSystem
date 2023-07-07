namespace InventoryManagementSystem.Core.entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductBrand> ProductBrands { get; set; } = new List<ProductBrand>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
