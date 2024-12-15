using System;
using System.Collections.Generic;

namespace postgres;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Photo { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
