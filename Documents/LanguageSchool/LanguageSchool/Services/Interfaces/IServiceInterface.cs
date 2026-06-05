namespace LanguageSchool.Services.Interfaces;

public interface IServiceInterface
{
    Task<List<T>> GetAllAsync<T>() where T : class;
    Task<T> GetByIdAsync<T>(int id) where T : class;
    Task<T> CreateAsync<T>(T entity) where T : class;
    Task<T> UpdateAsync<T>(int id, T entity) where T : class;
    Task DeleteAsync<T>(int id) where T : class;
}
