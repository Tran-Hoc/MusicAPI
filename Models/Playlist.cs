using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Playlist
{
    public int IdPlaylist { get; set; }

    public string? NamePlaylist { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
