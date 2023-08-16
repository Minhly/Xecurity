using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class TempDangerousDto
    {
        public int Id { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public DateTime? DateUploaded { get; set; }

        public virtual ServerRoom ServerRoom { get; set; }

        public virtual Location Location { get; set; }

        public virtual Address Address { get; set; }

        public virtual Sensor? Sensor { get; set; }

    }
}
