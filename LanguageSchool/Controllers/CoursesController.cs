using LanguageSchool.DTOs.Courses;
using LanguageSchool.Models;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    public ICoursesService _courseService;
    public CoursesController (ICoursesService coursesService)
    {
        this._courseService = coursesService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var courses = await _courseService.GetAllAsync();
        return Ok(courses);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id){
        var course = await _courseService.GetByIdAsync(id);
        var response = new ResponseCourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Level = course.Level,
            LanguageId = course.LanguageId
        };
        return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateCourseDto dto)
    {
        var course = new Course
        {
            Name = dto.Name,
            Level = dto.Level,
            LanguageId = dto.LanguageId
        };
        var createdCourse = await _courseService.CreateAsync(course);
        return CreatedAtAction(
            nameof(GetById), new { id = createdCourse.Id },
            createdCourse

        );
       
}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, UpdateCourseDto dto)
    {
       var course = new Course
        {
            Name = dto.Name,
            Level = dto.Level,
            LanguageId = dto.LanguageId
        };
        var updatedCourse = await _courseService.UpdateCourseAsync(id, course);
        return Ok(updatedCourse);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}