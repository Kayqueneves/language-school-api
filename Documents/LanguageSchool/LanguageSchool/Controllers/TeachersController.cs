using System.Net.WebSockets;
using LanguageSchool.DTOs.Teacher;
using LanguageSchool.Models;
using LanguageSchool.Services;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    public ITeachersService _teacherService;
    public TeachersController(ITeachersService teachersService)
    {
        this._teacherService = teachersService;
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var teacher = await _teacherService.GetAllTeachersAsync();
        return Ok(teacher);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetById(int id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        var response = new ResponseTeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Specialty = teacher.Specialty
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(CreateTeacherDto dto)
    {
        var t = new Teacher
        {
            FirstName = dto.FirstName,
            LastName =  dto.LastName,
            Specialty = dto.Specialty
        };
        var createdTeacher = await _teacherService.CreateTeacherAsync(t);
        return Ok(createdTeacher);
    }
        
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, UpdateTeacherDto dto)
    {
        var t = new Teacher
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Specialty = dto.Specialty
        };
        var updatedTeacher = await _teacherService.UpdateTeacherAsync(id, t);
        return Ok(updatedTeacher);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _teacherService.DeleteTeacherAsync(id);
        return NoContent();
    }
}

