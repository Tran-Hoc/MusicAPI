using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Avartar { get; set; }

    public int? Decentralization { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
