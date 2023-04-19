namespace InventoryManagementSystem.Core.entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdBrandProduct { get; set; }

    public virtual BrandProduct IdBrandProductNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
