using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface ITeacherLanguages
{
    Task<List<TeacherLanguages>> GetAllAsync();
    Task<TeacherLanguages> GetByIdAsync(int id);
    Task<TeacherLanguages> CreateAsync(TeacherLanguages teacherLanguages);
    Task DeleteAsync(int id);
    Task<TeacherLanguages>UpdateAsync(int id, TeacherLanguages teacherLanguages);
}
