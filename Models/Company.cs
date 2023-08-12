using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class Company
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Mail { get; set; }

    public int? Phone { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
