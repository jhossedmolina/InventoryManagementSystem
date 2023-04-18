namespace InventoryManagementSystem.Core.Entities;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
