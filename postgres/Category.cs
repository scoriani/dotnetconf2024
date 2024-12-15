using System;
using System.Collections.Generic;

namespace postgres;

public partial class Category
{
    public int Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
