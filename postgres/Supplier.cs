using System;
using System.Collections.Generic;

namespace postgres;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string? Suppliername { get; set; }

    public string? Contactname { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
