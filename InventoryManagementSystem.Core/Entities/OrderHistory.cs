﻿namespace InventoryManagementSystem.Core.entities;

public partial class OrderHistory
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdOrderSatus { get; set; }

    public DateTime UpdateDate { get; set; }

    public int IdOrderDetail { get; set; }

    public virtual OrderDetail IdOrderDetailNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual OrderStatus IdOrderSatusNavigation { get; set; } = null!;
}
