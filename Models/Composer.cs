using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Composer
{
    public int IdComposer { get; set; }

    public string? NameComposer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
