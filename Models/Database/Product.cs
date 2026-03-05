using System;
using System.Collections.Generic;

namespace InventorySys.Models.Database;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
