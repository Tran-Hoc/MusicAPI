public interface IGenresService{
    public Task<List<GenreVM>> GetAllGenresAsync();
    public Task<GenreVM> GetGenresAsync(int id);
    public Task<int> AddGenreAsync(GenreVM model);
    public Task UpdateGenreAsync(GenreVM model, int id);
    public Task DeleteGenreAsync(int id);
}