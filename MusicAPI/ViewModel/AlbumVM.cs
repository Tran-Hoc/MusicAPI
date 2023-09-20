using MusicAPI.Models;

namespace MusicAPI.ViewModel
{
    public class AlbumVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual Singer Singer { get; set; }
    }
}
