using AutoMapper;
using MusicAPI.Models;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {        
        CreateMap<Genre, GenreVM>().ReverseMap();
    }
}