using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Rating
{
    public int IdUser { get; set; }

    public int IdSong { get; set; }

    public DateTime? DateRate { get; set; }

    public int? Rating1 { get; set; }

    public int? Views { get; set; }
}
