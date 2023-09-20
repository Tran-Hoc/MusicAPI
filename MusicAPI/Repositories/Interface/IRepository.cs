using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Interface
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        public Task<int> AddAsync(T model);
        public Task<int> UpdateAsync(int id, T model);
        public Task<int> DeleteAsync(int id);
    }
}
