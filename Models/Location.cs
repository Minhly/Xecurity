using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<ServerRoom> ServerRooms { get; set; } = new List<ServerRoom>();
}
