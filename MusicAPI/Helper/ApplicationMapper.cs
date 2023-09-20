using AutoMapper;
using MusicAPI.Models;
using MusicAPI.ViewModel;

namespace MusicAPI.Helper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Genres, GenresVM>().ReverseMap();
            CreateMap<Singer, SingerVM>().ReverseMap();
            CreateMap<Album, AlbumVM>().ReverseMap();
            CreateMap<PlayList, PlaylistVM>().ReverseMap();
            CreateMap<Rating, RatingVM>().ReverseMap();
            CreateMap<Song, SongVM>().ReverseMap();


        }
    }
}
