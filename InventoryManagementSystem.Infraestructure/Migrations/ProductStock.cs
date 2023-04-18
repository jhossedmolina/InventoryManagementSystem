using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Infraestructure.Migrations;

public partial class ProductStock
{
    public int Id { get; set; }

    public int QuantityProduct { get; set; }

    public int IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();
}
