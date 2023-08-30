using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Singer
{
    public int IdSinger { get; set; }

    public string? NameSinger { get; set; }

    public string? PictureSinger { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
