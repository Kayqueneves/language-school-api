using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;

namespace LanguageSchool.Services;

public class LanguagesDbService : ILanguagesService
{
    private readonly IRepository<Language> _repository;

    public LanguagesDbService(IRepository<Language> repository)
    {
        _repository = repository;
    }

    public async Task<Language> CreateAsync(Language language)
    {
        if (string.IsNullOrWhiteSpace(language.Name))
            throw new Exception("Language name is required");

        return await _repository.CreateAsync(language);
    }

    public async Task DeleteAsync(int id)
    {
        var language = await _repository.GetByIdAsync(id);

        if (language == null)
            throw new Exception("Language not found");

        await _repository.DeleteAsync(id);
    }

    public async Task<List<Language>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Language> GetByIdAsync(int id)
    {
        var language = await _repository.GetByIdAsync(id);

        if (language == null)
            throw new Exception("Language not found");

        return language;
    }

    public async Task<Language> UpdateAsync(int id, Language newLanguage)
    {
        var language = await _repository.GetByIdAsync(id);

        if (language == null)
            throw new Exception("Language not found");

        if (string.IsNullOrWhiteSpace(newLanguage.Name))
            throw new Exception("Language name is required");

        language.Name = newLanguage.Name;

        return await _repository.UpdateAsync(id, language);
    }
}