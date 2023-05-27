using System;
using System.Collections.Generic;

namespace ShopProject;

public partial class Manufacturer
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
