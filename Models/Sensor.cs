using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XecurityAPI.Models;

public partial class Sensor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ServerRoomId { get; set; }

    public int? SensorTypeId { get; set; }

    public virtual SensorType? SensorType { get; set; }

    public virtual ServerRoom? ServerRoom { get; set; }

    public virtual ICollection<TemperatureDatum> TemperatureData { get; set; } = new List<TemperatureDatum>();
}
