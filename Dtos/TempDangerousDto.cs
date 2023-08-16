using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class TempDangerousDto
    {
        public int Id { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public DateTime? DateUploaded { get; set; }
        public string ServerRoomName { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }

    }
}
