using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.DTOs.StudentGrades;
using LanguageSchool.Models;


namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGradeController : ControllerBase
{
    readonly IStudentGradesService _studentGradeService;
    public StudentGradeController(IStudentGradesService studentGradeService)
    {
        this._studentGradeService = studentGradeService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var studentGrades = await _studentGradeService.GetAllAsync();
        return Ok(studentGrades);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var studentGrade = await _studentGradeService.GetByIdAsync(id);
        var response = new ResponseStudentGradeDto
        {
            Id = studentGrade.Id,
            StudentId = studentGrade.StudentId,
            AssesmentId = studentGrade.AssesmentId,
            Score = studentGrade.Score
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentGradeDto dto)
    {
        var studentGrade = new StudentGrade
        {
            StudentId = dto.StudentId,
            AssesmentId = dto.AssesmentId,
            Score = dto.Score
        };
        var createdStudentGrade = await _studentGradeService.PostAsync(studentGrade);
        return Ok(createdStudentGrade);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateStudentGradeDto dto)
    {
        var studentGrade = new StudentGrade
        {
            
            StudentId = dto.StudentId,
            AssesmentId = dto.AssesmentId,
            Score = dto.Score
        };
        var updatedStudentGrade = await _studentGradeService.UpdateAsync(id, studentGrade);
        return Ok(updatedStudentGrade);
    }
}
