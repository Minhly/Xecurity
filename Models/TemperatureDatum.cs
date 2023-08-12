using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class TemperatureDatum
{
    public int Id { get; set; }

    public double? Temperature { get; set; }

    public double? Humidity { get; set; }

    public DateTime? DateUploaded { get; set; }

    public int? SensorId { get; set; }

    public virtual Sensor? Sensor { get; set; }
}
