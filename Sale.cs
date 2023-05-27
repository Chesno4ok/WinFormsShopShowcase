using System;
using System.Collections.Generic;

namespace ShopProject;

public partial class Sale
{
    public long Id { get; set; }

    public long? User { get; set; }

    public long? Product { get; set; }

    public string? Date { get; set; }

    public string? CardData { get; set; }

    public virtual Product? ProductNavigation { get; set; }

    public virtual User? UserNavigation { get; set; }
}
