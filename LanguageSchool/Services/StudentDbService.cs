using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using LanguageSchool.Services.Interfaces;

namespace LanguageSchool.Services;

public class StudentDbService : IStudentsService
{
    private readonly IRepository<Student> _repository;
    public StudentDbService(IRepository<Student> repository)
    {
        this._repository = repository;
    }
    public async Task<Student> CreateAsync(Student student)
    {
        var studentc = new Student
        {
            Name = student.Name,
            Age = student.Age,
            Level = student.Level,
            RegistrationNumber =
            $"REG-{Guid.NewGuid().ToString("N")[..8].ToUpper()}"
        };
        return await _repository.CreateAsync(studentc);
    }
    public async Task<Student> GetByIdAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student != null)
        {
            return student;
        }
        throw new Exception("Student not found");
    }
    
    public async Task DeleteStudentAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student != null)
        {
            await _repository.DeleteAsync(id);
        }
    }
    public async Task<Student> UpdateStudentAsync(int id, Student student)
    {
        var existingStudent = await _repository.GetByIdAsync(id);
        if (existingStudent == null)
        {
            throw new Exception("Student not found");
        }
        existingStudent.Name = student.Name;
        existingStudent.Level = student.Level;
        existingStudent.Age = student.Age;
        existingStudent.RegistrationNumber = student.RegistrationNumber;
        await _repository.UpdateAsync(id, existingStudent);
        return existingStudent;
    }
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _repository.GetAllAsync();
    }

    
}

