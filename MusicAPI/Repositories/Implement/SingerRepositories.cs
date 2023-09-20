using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Implement
{
    public class SingerRepositories : ISingerRepository
    {
        private readonly MusicContext _context;
        private readonly IMapper _mapper;
        public SingerRepositories(MusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddAsync(SingerVM model)
        {
            var newModel = _mapper.Map<Singer>(model);
            _context.Singers!.Add(newModel);
            await _context.SaveChangesAsync();

            return newModel.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delModel = _context.Singers!.SingleOrDefault(b => b.Id == id);
            if (delModel != null)
            {
                _context.Singers!.Remove(delModel);
                await _context.SaveChangesAsync();
                return delModel.Id;
            }
            return -1;
        }

        public async  Task<List<SingerVM>> GetAllAsync()
        {
            var models = await _context.Genres!.ToListAsync();
            return _mapper.Map<List<SingerVM>>(models);
        }

        public async Task<SingerVM> GetAsync(int id)
        {
            var model = await _context.Singers!.FindAsync(id);
            return _mapper.Map<SingerVM>(model);
        }

        public async Task<int> UpdateAsync(int id, SingerVM model)
        {

            if (id == model.Id)
            {
                var updateModel = _mapper.Map<Singer>(model);

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
            return (_context.Singers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
