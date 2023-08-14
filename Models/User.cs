using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public int? UserTypeId { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public virtual ICollection<KeyCard> KeyCards { get; set; } = new List<KeyCard>();

    public virtual UserType? UserType { get; set; }
}
