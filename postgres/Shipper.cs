using System;
using System.Collections.Generic;

namespace postgres;

public partial class Shipper
{
    public int Shipperid { get; set; }

    public string? Shippername { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
