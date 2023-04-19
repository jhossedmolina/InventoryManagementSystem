namespace InventoryManagementSystem.Core.entities;

public partial class ProductHistory
{
    public int Id { get; set; }

    public int QuantityProduct { get; set; }

    public int IdProductMovement { get; set; }

    public DateTime UpdateDate { get; set; }

    public int IdProduct { get; set; }

    public int? IdProductStock { get; set; }

    public int? IdOrderDetail { get; set; }

    public virtual OrderDetail? IdOrderDetailNavigation { get; set; }

    public virtual ProductMovement IdProductMovementNavigation { get; set; } = null!;

    public virtual ProductStock? IdProductStockNavigation { get; set; }
}
