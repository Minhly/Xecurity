using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class SensorType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
