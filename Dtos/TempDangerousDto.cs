using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class TempDangerousDto
    {
        public int Id { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public DateTime? DateUploaded { get; set; }

        public int? SensorId { get; set; }

        public virtual ServerRoom ServerRoom { get; set; }

        public virtual Sensor? Sensor { get; set; }
    }
}
