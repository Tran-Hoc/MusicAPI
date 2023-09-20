using MusicAPI.Models;

namespace MusicAPI.ViewModel
{
    public class SongVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? SongUrl { get; set; }
        public string? PictureUrl { get; set; }
        public virtual Album? Album { get; set; }
        public virtual Genres? Genres { get; set; }
        public virtual Singer? Singer { get; set; }
    }
}
