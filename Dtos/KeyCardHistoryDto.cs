using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class KeyCardHistoryDto
    {
        public int Id { get; set; }

        public DateTime? DateUploaded { get; set; }

        public string? Status { get; set; }

        public string? ImageData { get; set; }

        public string User { get; set; }

        public int KeyCardId { get; set; }

        public string ServerRoomName { get; set; }
        public string LocationName { get; set;}

        public string AddressName { get; set; }
    }
}
