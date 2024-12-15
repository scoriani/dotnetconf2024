using System;
using System.Collections.Generic;

namespace postgres;

public partial class Product
{
    public int Productid { get; set; }

    public string? Productname { get; set; }

    public int? Supplierid { get; set; }

    public int? Categoryid { get; set; }

    public string? Unit { get; set; }

    public decimal? Price { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Supplier? Supplier { get; set; }
}
