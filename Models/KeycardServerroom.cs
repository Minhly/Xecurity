using System;
using System.Collections.Generic;

namespace XecurityAPI.Models;

public partial class KeycardServerroom
{
    public int Id { get; set; }

    public int? ServerRoomId { get; set; }

    public int? KeyCardId { get; set; }

    public virtual KeyCard? KeyCard { get; set; }

    public virtual ServerRoom? ServerRoom { get; set; }
}
