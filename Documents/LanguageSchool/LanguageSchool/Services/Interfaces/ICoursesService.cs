using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface ICoursesService
{
    Task <Course> CreateAsync(Course course);
    Task DeleteCourseAsync(int id);
    Task <Course> GetByIdAsync(int id);
    Task <Course> UpdateCourseAsync(int id, Course course);
    Task <List<Course>> GetAllAsync();
        
}
