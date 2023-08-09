using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? Addresse { get; set; }

    public int? Postnr { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
