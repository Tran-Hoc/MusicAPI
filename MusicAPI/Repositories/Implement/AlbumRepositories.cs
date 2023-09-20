using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Implement
{
    public class AlbumRepositories : IAlbumRepositories
    {
        private readonly MusicContext _context;
        private readonly IMapper _mapper;
        public AlbumRepositories(MusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> AddAsync(AlbumVM model)
        {
            var newModel = _mapper.Map<Album>(model);
            _context.Albums!.Add(newModel);
            await _context.SaveChangesAsync();

            return newModel.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delModel = _context.Albums!.SingleOrDefault(b => b.Id == id);
            if (delModel != null)
            {
                _context.Albums!.Remove(delModel);
                await _context.SaveChangesAsync();
                return delModel.Id;
            }
            return -1;
        }

        public async Task<List<AlbumVM>> GetAllAsync()
        {
            var models = await _context.Albums!.ToListAsync();
            return _mapper.Map<List<AlbumVM>>(models);
        }

        public async Task<AlbumVM> GetAsync(int id)
        {
            var model = await _context.Albums!.FindAsync(id);
            return _mapper.Map<AlbumVM>(model);
        }
        public async Task<int> UpdateAsync(int id, AlbumVM model)
        {
            if (id == model.Id)
            {
                var updateModel = _mapper.Map<AlbumVM>(model);

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
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
