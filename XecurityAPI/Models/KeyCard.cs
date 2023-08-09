using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class KeyCard
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public DateTime? ExpDate { get; set; }

    public bool? Active { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<KeyCardDataHistory> KeyCardDataHistories { get; set; } = new List<KeyCardDataHistory>();

    public virtual ICollection<KeycardServerroom> KeycardServerrooms { get; set; } = new List<KeycardServerroom>();

    public virtual User? User { get; set; }
}
