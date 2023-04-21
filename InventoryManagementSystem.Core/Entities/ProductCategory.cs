namespace InventoryManagementSystem.Core.entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdProductBrand { get; set; }

    public virtual ProductBrand IdProductBrandNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
