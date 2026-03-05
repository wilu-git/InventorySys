using System;
using System.Collections.Generic;

namespace InventorySys.Models.Database;

public partial class Order
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
