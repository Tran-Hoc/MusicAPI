namespace MusicAPI.Models
{
    public class PlayList
    {
        public int Id { get; set; }
        public int Position { get; set; }

        public virtual User User{ get; set; }
        public virtual Song Song { get; set; }
    }
}
