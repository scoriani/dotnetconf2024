using System;
using System.Collections.Generic;

namespace postgres;

public partial class Customer
{
    public int Customerid { get; set; }

    public string? Customername { get; set; }

    public string? Contactname { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
