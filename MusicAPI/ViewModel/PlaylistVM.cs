using MusicAPI.Models;

namespace MusicAPI.ViewModel
{
    public class PlaylistVM
    {
        public int Id { get; set; }
        public int Position { get; set; }

        public virtual User User { get; set; }
        public virtual Song Song { get; set; }
    }
}
