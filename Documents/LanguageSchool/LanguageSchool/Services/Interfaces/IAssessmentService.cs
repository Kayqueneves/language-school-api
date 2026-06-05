using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface IAssesmentService
{
    Task <List<Assessment>> GetAllAsync();
    Task <Assessment> GetByIdAsync(int id);
    Task <Assessment> CreateAsync(Assessment assesment);
    Task <Assessment> UpdateAsync(int id, Assessment newAssessment);
    Task DeleteAsync(int id);
}
