
using LanguageSchool.DTOs.Assesments;
using LanguageSchool.Models;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessmentController : ControllerBase
{
    private readonly IAssesmentService _assessementService;
    public AssessmentController(IAssesmentService assesmentService)
    {
        this._assessementService = assesmentService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateAssessmentDto dto)
    {
        var assessment = new Assessment
        {
            Title = dto.Title,
            MaxScore = dto.MaxScore,
            ClassId = dto.ClassId
        };
        var createdAssessment = await _assessementService.CreateAsync(assessment);
        return Ok(createdAssessment);

    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _assessementService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var assessment = await _assessementService.GetByIdAsync(id);
        var response = new ResponseAssesmentDto
        {
            Id = assessment.Id,
            Title = assessment.Title,
            MaxScore = assessment.MaxScore,
            ClassId = assessment.ClassId
        };

        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateAssessementDto dto)
    {
        var assessment = new Assessment
        {
            ClassId = dto.ClassId,
            Title = dto.Title,
            MaxScore = dto.MaxScore
        };
        var updatedAssessment = await _assessementService.UpdateAsync(id, assessment);
        return Ok(updatedAssessment);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _assessementService.DeleteAsync(id);
        return NoContent();
    }
}


