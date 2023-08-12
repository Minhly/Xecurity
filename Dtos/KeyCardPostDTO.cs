using XecurityAPI.Models;

namespace XecurityAPI.Dtos
{
    public class KeyCardPostDTO
    {
        public int Id { get; set; }

        public string? Password { get; set; }

        public DateTime? ExpDate { get; set; }

        public bool? Active { get; set; }

        public int? UserId { get; set; }

        public virtual ICollection<KeycardServerroom> KeycardServerrooms { get; set; } = new List<KeycardServerroom>();
    }
}
