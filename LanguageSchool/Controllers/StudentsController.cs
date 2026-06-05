
using LanguageSchool.DTOs.Students;
using LanguageSchool.Models;
using LanguageSchool.Services;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    public IStudentsService _studentDbService;
    public StudentsController(IStudentsService studentsService)
    {
        this._studentDbService = studentsService;
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var student = await _studentDbService.GetAllStudentsAsync();
        return Ok(student);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var student = await _studentDbService.GetByIdAsync(id);
        var response = new StudentResponseDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Level = student.Level,
            RegistrationNumber = student.RegistrationNumber
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Create(CreateStudentDto dto)
    {
        var s = new Student
        {
            Name = dto.Name,
            Age = dto.Age,
            Level = dto.Level,
            RegistrationNumber = $"ENR-{Guid.NewGuid().ToString("N")[..8].ToUpper()}",
        };
         var createdStudent = await _studentDbService.CreateAsync(s);
        return Ok(createdStudent);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _studentDbService.DeleteStudentAsync(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put( int id, UpdateStudentDto dto)
    {
        var s = new Student
        {
            Name = dto.Name,
            Age = dto.Age,
            Level = dto.Level
        };
        var updatedStudent = await _studentDbService.UpdateStudentAsync(id, s);
        return Ok(updatedStudent);
    }
}
