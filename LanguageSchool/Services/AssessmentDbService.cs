using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;
namespace LanguageSchool.Services;

public class AssesmentDbService : IAssesmentService
{
    public readonly IRepository<Assessment> _repository;
   public AssesmentDbService(IRepository<Assessment> repository)
    {
        _repository = repository;
    }
    public async Task<Assessment> CreateAsync(Assessment assessment)
    {
        if (assessment.MaxScore <= 0)
        {
            throw new Exception("Max score must be greater than zero");
        }
        return await _repository.CreateAsync(assessment);
    }

    public async Task DeleteAsync(int id)
    {
        var assessment = await _repository.GetByIdAsync(id);
        if (assessment == null)
        {
            throw new Exception("Assessment not found");
        }
        await _repository.DeleteAsync(id);
    }

    public async Task<List<Assessment>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task <Assessment> GetByIdAsync(int id)
    {
        var assessment = await _repository.GetByIdAsync(id);
        if(assessment == null){
            throw new Exception("Assessment not found");
        }
        return assessment;
    }

    public async Task<Assessment> UpdateAsync(int id, Assessment newAssessment)
    {
        var assessment = await _repository.GetByIdAsync(id);
        if (assessment == null)
        {
                throw new Exception("Assessment not found");
        }
        assessment.Title = newAssessment.Title;
        assessment.MaxScore = newAssessment.MaxScore;
        return assessment;
    }

     

}

