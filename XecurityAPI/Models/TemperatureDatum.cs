using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class TemperatureDatum
{
    public int Id { get; set; }

    public float? Temperature { get; set; }

    public float? Humidity { get; set; }

    public DateTime? DateUploaded { get; set; }

    public int? SensorId { get; set; }

    public virtual Sensor? Sensor { get; set; }
}
