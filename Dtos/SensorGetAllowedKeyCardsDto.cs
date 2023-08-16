using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class SensorGetAllowedKeyCardsDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string ServerRoomName { get; set; }

        public string LocationName { get; set; }

        public string KeyCardPassword { get; set; }

        public bool KeyCardActive { get; set; }
    }
}
