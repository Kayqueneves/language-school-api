using LanguageSchool.Models;
using Microsoft.EntityFrameworkCore;
namespace LanguageSchool.Services.Interfaces;


public interface IClassesService
{
    Task <List<SchoolClass>> GetAllAsync();
    Task <SchoolClass> GetByIdAsync(int id);
    Task<SchoolClass> CreateClassAsync(SchoolClass sclass);
    Task <SchoolClass> UpdateAsync(int id, SchoolClass sclass);
    Task DeleteAsync(int id);
}
