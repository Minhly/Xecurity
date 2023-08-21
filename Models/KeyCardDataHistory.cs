using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class KeyCardDataHistory
{
    public int Id { get; set; }

    public DateTime? DateUploaded { get; set; }

    public string? Status { get; set; }

    public string? ImageData { get; set; }

    public string? ServerRoomName { get; set; }

    public int? KeyCardId { get; set; }

    public virtual KeyCard? KeyCard { get; set; }
}
