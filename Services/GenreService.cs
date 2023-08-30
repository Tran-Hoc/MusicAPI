using AutoMapper;
using MusicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class GenresService : IGenresService
{
    private WebMusicContext _context;
    private IMapper _mapper;

    public GenresService(WebMusicContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> AddGenreAsync(GenreVM model)
    {
       var newModel = _mapper.Map<Genre>(model);
       _context.Genres!.Add(newModel);
       await _context.SaveChangesAsync();
       return newModel.IdGenre;
    }

    public async Task DeleteGenreAsync(int id)
    {
        var deleteModel = _context.Genres!.SingleOrDefault(m => m.IdGenre == id);
        if(deleteModel != null){
            _context.Genres!.Remove(deleteModel);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<GenreVM>> GetAllGenresAsync()
    {
        var model = await _context.Genres!.ToListAsync();
        return _mapper.Map<List<GenreVM>>(model);
    }

    public async Task<GenreVM> GetGenresAsync(int id)
    {
        var model = await _context.Genres!.FindAsync(id);
        return _mapper.Map<GenreVM>(model);
    }

    public async Task UpdateGenreAsync(GenreVM model, int id)
    {
        if(id == model.IdGenre){
            var updateModel = _mapper.Map<Genre>(model);
            _context.Genres!.Update(updateModel);
            await _context.SaveChangesAsync();
        }
    }
}