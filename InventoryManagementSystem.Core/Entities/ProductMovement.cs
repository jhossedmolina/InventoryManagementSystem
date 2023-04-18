namespace InventoryManagementSystem.Core.Entities;

public partial class ProductMovement
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();
}
