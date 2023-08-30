using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Genre
{
    public int IdGenre { get; set; }

    public string? NameGenre { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
