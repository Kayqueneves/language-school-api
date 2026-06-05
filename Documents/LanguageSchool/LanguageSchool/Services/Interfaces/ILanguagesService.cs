using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface ILanguagesService
{
    Task<Language> CreateAsync(Language language);
    Task<Language> GetByIdAsync(int id);
    Task<List<Language>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<Language> UpdateAsync(int id, Language newLanguage);
}
