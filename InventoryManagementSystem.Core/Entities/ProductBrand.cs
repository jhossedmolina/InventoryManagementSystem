namespace InventoryManagementSystem.Core.entities;

public partial class ProductBrand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdProductCategory { get; set; }

    public virtual ProductCategory IdProductCategoryNavigation { get; set; } = null!;
}
