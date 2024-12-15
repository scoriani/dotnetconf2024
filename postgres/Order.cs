using System;
using System.Collections.Generic;

namespace postgres;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Customerid { get; set; }

    public int? Employeeid { get; set; }

    public DateTime? Orderdate { get; set; }

    public int? Shipperid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Shipper? Shipper { get; set; }
}
