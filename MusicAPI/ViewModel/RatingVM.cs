using MusicAPI.Models;

namespace MusicAPI.ViewModel
{
    public class RatingVM
    {
        public int Id { get; set; }
        public DateTime TimeRating { get; set; }
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public virtual User User { get; set; }
        public virtual Song Song { get; set; }
    }
}
