namespace MusicAPI.Models
{
    public class Song
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? SongUrl { get; set; }
        public string? PictureUrl { get; set; }
        //public int IdSinger { get; set; }
        //public int IdGenres { get; set; }
        //public int IdAlbum { get; set; }
        public virtual Album? Album { get; set; }
        public virtual Genres? Genres { get; set; }
        public virtual Singer? Singer { get; set; }
    }
}
