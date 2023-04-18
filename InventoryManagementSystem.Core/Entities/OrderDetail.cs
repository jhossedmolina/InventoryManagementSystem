namespace InventoryManagementSystem.Core.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public DateTime UpdateDate { get; set; }

    public int IdOrder { get; set; }

    public string Observations { get; set; } = null!;

    public int IdProductHistory { get; set; }

    public int QuantityProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();
}
