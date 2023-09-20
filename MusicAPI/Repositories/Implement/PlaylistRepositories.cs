using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Implement
{
    public class PlaylistRepositories: IPlaylistRepositories
    {

        private readonly MusicContext _context;
        private readonly IMapper _mapper;
        public PlaylistRepositories(MusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddAsync(PlaylistVM model)
        {
            var newModel = _mapper.Map<PlayList>(model);
            _context.PlayLists!.Add(newModel);
            await _context.SaveChangesAsync();

            return newModel.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delModel = _context.PlayLists!.SingleOrDefault(b => b.Id == id);
            if (delModel != null)
            {
                _context.PlayLists!.Remove(delModel);
                await _context.SaveChangesAsync();
                return delModel.Id;
            }
            return -1;
        }

        public async Task<List<PlaylistVM>> GetAllAsync()
        {
            var models = await _context.Genres!.ToListAsync();
            return _mapper.Map<List<PlaylistVM>>(models);
        }

        public async Task<PlaylistVM> GetAsync(int id)
        {
            var model = await _context.Genres!.FindAsync(id);
            return _mapper.Map<PlaylistVM>(model);
        }

        public async Task<int> UpdateAsync(int id, PlaylistVM model)
        {
            if (id == model.Id)
            {
                var updateModel = _mapper.Map<PlayList>(model);

                _context.Entry(updateModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(id))
                    {
                        return -1;
                    }
                    else
                    {
                        throw;
                    }
                }

                return model.Id;
            }
            return -1;
        }
        private bool ModelExists(int id)
        {
            return (_context.PlayLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
