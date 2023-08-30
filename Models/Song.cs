using System;
using System.Collections.Generic;

namespace MusicAPI.Models;

public partial class Song
{
    public int IdSong { get; set; }

    public int? IdSinger { get; set; }

    public int? IdAlbum { get; set; }

    public int? IdGenre { get; set; }

    public string? NameSong { get; set; }

    public string? PathSong { get; set; }

    public string? PictureSong { get; set; }

    public int? IdComposer { get; set; }

    public virtual Album? IdAlbumNavigation { get; set; }

    public virtual Composer? IdComposerNavigation { get; set; }

    public virtual Genre? IdGenreNavigation { get; set; }

    public virtual Singer? IdSingerNavigation { get; set; }
}
