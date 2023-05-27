using System;
using System.Collections.Generic;

namespace ShopProject;

public partial class User
{
    public long Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
