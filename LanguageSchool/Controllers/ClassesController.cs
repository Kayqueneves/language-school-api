using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.Models;
using LanguageSchool.DTOs.Courses;
using LanguageSchool.Services;
using LanguageSchool.DTOs.Classes;

namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    public IClassesService _schoolClassService;
    public ClassesController (IClassesService schoolClassService)
    {
        this._schoolClassService = schoolClassService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var schoolClasses = await _schoolClassService.GetAllAsync();
        return Ok(schoolClasses);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var schoolClass = await _schoolClassService.GetByIdAsync(id);
        var response = new SchoolClassResponseDto
        {
            Id = id,
            CourseId = schoolClass.CourseId,
            TeacherId = schoolClass.TeacherId,
            MaxStudents = schoolClass.MaxStudents,
            RoomId = schoolClass.RoomId,
            ScheduleId = schoolClass.ScheduleId

        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateClassDto dto)
    {
        var schoolClass = new SchoolClass
        {
            CourseId = dto.CourseId,
            TeacherId = dto.TeacherId,
            MaxStudents = dto.MaxStudents,
            RoomId = dto.RoomId,
            ScheduleId = dto.ScheduleId
        };
        var createdClass = await _schoolClassService.CreateClassAsync(schoolClass);
        return Ok(createdClass);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SchoolclassUpdateDto dto)
    {
        var schoolClass = new SchoolClass
        {
            CourseId = dto.CourseId,
            TeacherId = dto.TeacherId,
            MaxStudents = dto.MaxStudents,
            RoomId = dto.RoomId
        };
        var updatedClass = await _schoolClassService.UpdateAsync(id, schoolClass);
        return Ok(updatedClass);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _schoolClassService.DeleteAsync(id);
        return NoContent();
    }
}
