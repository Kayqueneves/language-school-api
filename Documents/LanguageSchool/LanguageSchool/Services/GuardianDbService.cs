using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.Repository.Interfaces;
namespace LanguageSchool.Services;

public class GuardianDbService : IGuardiansService
{
    private readonly IRepository<Guardian> _repository;
    public GuardianDbService(IRepository<Guardian> repository)
    {
        this._repository = repository;
    }
    public async Task<Guardian> CreateGuardianAsync(Guardian guardian)
    {
        await _repository.CreateAsync(guardian);
        return guardian;
    }
    public async Task<List<Guardian>> GetAllGuardiansAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<Guardian> GetByIdAsync(int id)
    {
        var guardian = await _repository.GetByIdAsync(id);
        if (guardian != null)
        {
            return guardian;
        }
        throw new Exception("Guardian not found");
    }
    public async Task DeleteGuardianAsync(int id)
    {
        var guardian = await _repository.GetByIdAsync(id);
        if (guardian != null)
        {
            await _repository.DeleteAsync(id);
        }
        throw new Exception("Guardian not found");
    }

     public async Task<Guardian> UpdateGuardianAsync(int id, Guardian guardian)
    {
        var existingGuardian = await _repository.GetByIdAsync   (id);
        if (existingGuardian == null)
        {
            throw new Exception("Guardian not found");
        }
        existingGuardian.Name = guardian.Name;
        existingGuardian.Email = guardian.Email;
        await _repository.UpdateAsync(id, existingGuardian);
        return existingGuardian;
    }


}
   

