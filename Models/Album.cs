using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Album
{
    public int IdAlbum { get; set; }

    public string? NameAlbum { get; set; }

    public int? IdSinger { get; set; }

    public string? PictureAlbum { get; set; }

    public virtual Singer? IdSingerNavigation { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
