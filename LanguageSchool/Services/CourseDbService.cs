using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;



namespace LanguageSchool.Services;

public class CourseDbService : ICoursesService
{
    private readonly IRepository<Course> _repository;
    public CourseDbService(IRepository<Course> repository)
    {
        this._repository = repository;
    }
    public async Task<Course> CreateAsync(Course course)
    {
        return await _repository.CreateAsync(course);
    }
    public async Task<Course> GetByIdAsync(int id)
    {
      var course =   await _repository.GetByIdAsync(id);
        if (course != null)
        {
            return course;
        }
        throw new Exception("Course not found");
    }
    public async Task<List<Course>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task DeleteCourseAsync(int id)
    {
        var course = await _repository.GetByIdAsync(id);
        if (course != null)
        {
            await _repository.DeleteAsync(id);
        }
    }
    public async Task<Course> UpdateCourseAsync(int id, Course course)
    {
        var updatedCourse = await _repository.GetByIdAsync(id);
        if (updatedCourse == null)
        {
            throw new Exception("Course not found");
        }
        updatedCourse.Name = course.Name;
        updatedCourse.Level = course.Level;
        updatedCourse.LanguageId = course.LanguageId;
        await _repository.UpdateAsync(id, updatedCourse);
        return updatedCourse;
        
    }


}
