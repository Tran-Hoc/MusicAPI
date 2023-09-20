using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Interface
{
    public class IGenresRepository : IRepository<GenresVM>
    {
        public Task<int> AddAsync(GenresVM model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GenresVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenresVM> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, GenresVM model)
        {
            throw new NotImplementedException();
        }
    }
}
