using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using LanguageSchool.Services.Interfaces;

namespace LanguageSchool.Services;

public class TeacherDbService : ITeachersService
{
    private readonly IRepository<Teacher> _repository;
    public TeacherDbService(IRepository<Teacher> repository)
    {
            this._repository = repository;
        }
    public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
    {
        await _repository.CreateAsync(teacher);
        return teacher;
    }
    public async Task <List<Teacher>> GetAllTeachersAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<Teacher> GetByIdAsync(int id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher != null)
        {
            return teacher;
        }
        throw new Exception("Teacher not found");

    }
    public async Task DeleteTeacherAsync(int id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher != null)
        {
            await _repository.DeleteAsync(id);
        }
        throw new Exception("Teacher not found");
    }
    public async Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher)
    {
        var existingTeacher = await _repository.GetByIdAsync(id);
        if (existingTeacher == null)
        {
            throw new Exception("Teacher not found");
        }
        existingTeacher.FirstName = teacher.FirstName;
        existingTeacher.LastName = teacher.LastName;
        existingTeacher.Specialty = teacher.Specialty;
        await _repository.UpdateAsync(id, existingTeacher);
        return existingTeacher;
    }
}
