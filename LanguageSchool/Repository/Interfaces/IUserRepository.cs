using LanguageSchool.Models;
namespace LanguageSchool.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task<User> CreateAsync(User user);

    Task<User> UpdateAsync(User user);

    Task DeleteAsync(int id);
}
