using System;
using System.Collections.Generic;

namespace ShopProject;

public partial class Product
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public long? Manufacturer { get; set; }

    public long? Quantity { get; set; }

    public virtual Manufacturer? ManufacturerNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
