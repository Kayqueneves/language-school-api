using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Repository.Implementations;
using LanguageSchool.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LanguageSchool.Services;

public class ClassesDbService : IClassesService
{
    private readonly IRepository<SchoolClass> _repository;
    public ClassesDbService(IRepository<SchoolClass> repository)
    {
        this._repository = repository;
    }
    public async Task<SchoolClass> CreateClassAsync(SchoolClass schoolClass)
    {
        return await _repository.CreateAsync(schoolClass);
    }
    public async Task<List<SchoolClass>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<SchoolClass> GetByIdAsync(int id)
    {
        var schoolClass = await _repository.GetByIdAsync(id);
        if (schoolClass != null)
        {
            return schoolClass;
        }
        throw new Exception("Class not found");

    }
    public async Task<SchoolClass> UpdateAsync(int id, SchoolClass sclass)
    {
        var existingClass = await _repository.GetByIdAsync(id);
        if (existingClass == null)
        {
            throw new Exception("Class not found");
        }
        existingClass.MaxStudents = sclass.MaxStudents;
        existingClass.TeacherId = sclass.TeacherId;
        return await _repository.UpdateAsync(id, existingClass);
    }
    public async Task DeleteAsync   (int id)
    {
        var schoolClass = await _repository.GetByIdAsync(id);
        if (schoolClass != null)
        {
            await _repository.DeleteAsync(id);
        }
    }

    
}
