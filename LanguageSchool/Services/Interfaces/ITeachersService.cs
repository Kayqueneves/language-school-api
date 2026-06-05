using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface ITeachersService
{
    Task <Teacher> CreateTeacherAsync(Teacher teacher);
    Task  DeleteTeacherAsync(int id);
    Task <Teacher> GetByIdAsync(int id);
    Task <Teacher> UpdateTeacherAsync(int id, Teacher teacher);
    Task <List<Teacher>> GetAllTeachersAsync();
}
