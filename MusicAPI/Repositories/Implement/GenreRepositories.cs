using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Implement
{
    public class GenreRepositories : IGenresRepository
    {
        private readonly MusicContext _context;
        private readonly IMapper _mapper;
        public GenreRepositories(MusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddAsync(GenresVM model)
        {
            var newModel = _mapper.Map<Genres>(model);
            _context.Genres!.Add(newModel);
            await _context.SaveChangesAsync();

            return newModel.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delModel = _context.Genres!.SingleOrDefault(b => b.Id == id);
            if (delModel != null)
            {
                _context.Genres!.Remove(delModel);
                await _context.SaveChangesAsync();
                return delModel.Id;
            }
            return -1;
        }

        public async Task<List<GenresVM>> GetAllAsync()
        {
            var models = await _context.Genres!.ToListAsync();
            return _mapper.Map<List<GenresVM>>(models);
        }

        public async Task<GenresVM> GetAsync(int id)
        {
            var model = await _context.Genres!.FindAsync(id);
            return _mapper.Map<GenresVM>(model);
        }

        public async Task<int> UpdateAsync(int id, GenresVM model)
        {
            if (id == model.Id)
            {
                var updateModel = _mapper.Map<Genres>(model);

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

                //_context.Genres!.Update(updateBook);
                //await _context.SaveChangesAsync();
                return model.Id;
            }
            return -1;
        }
        private bool ModelExists(int id)
        {
            return (_context.Genres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
