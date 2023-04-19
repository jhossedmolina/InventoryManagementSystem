namespace InventoryManagementSystem.Core.entities;

public partial class Order
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public string Description { get; set; } = null!;

    public int IdOrderStatus { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual OrderStatus IdOrderStatusNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();
}
