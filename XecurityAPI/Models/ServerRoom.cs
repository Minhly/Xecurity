using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class ServerRoom
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? LocationId { get; set; }

    public virtual ICollection<KeycardServerroom> KeycardServerrooms { get; set; } = new List<KeycardServerroom>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
