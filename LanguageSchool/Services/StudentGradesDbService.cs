using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;
namespace LanguageSchool.Services;

public class StudentGradesDbService : IStudentGradesService {


    readonly IRepository<StudentGrade> _repository;
    public StudentGradesDbService(IRepository<StudentGrade> repository)
    {
        this._repository = repository;
    }
    public async Task<List<StudentGrade>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<StudentGrade> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<StudentGrade> PostAsync(StudentGrade studentGrades)
    {
        return await _repository.CreateAsync(studentGrades);
    }
    

    public async Task<StudentGrade> UpdateAsync(int id, StudentGrade studentGrades)
    {
        return await _repository.UpdateAsync(id, studentGrades);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}