using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface IGuardiansService
{
    Task DeleteGuardianAsync(int id);
    Task <Guardian> GetByIdAsync(int id);
    Task <List<Guardian>> GetAllGuardiansAsync();
    Task <Guardian> CreateGuardianAsync(Guardian guardian);
    Task <Guardian> UpdateGuardianAsync(int id, Guardian guardian);
}
