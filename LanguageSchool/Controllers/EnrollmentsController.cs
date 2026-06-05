using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.Models;
using LanguageSchool.DTOs.Enrrollments;
using AssessmentDbService.DTOs.Enrrollments;

namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    public IEnrollmentsService _enrollmentsService;
    public EnrollmentsController(IEnrollmentsService enrollmentsService)
    {
        this._enrollmentsService = enrollmentsService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _enrollmentsService.GetAllAsync());
    }
    [HttpPost]
    public async Task<ActionResult<Enrollment>> Post(CreateEnrollmentDto enrollmentDto)
    {
        try
        {
            var enrollment = await _enrollmentsService.CreateAsync(
                    enrollmentDto.StudentId,
                    enrollmentDto.ClassId
                    
            );
            return Ok(enrollment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _enrollmentsService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var enrollment = await _enrollmentsService.GetByIdAsync(id);
            var response = new EnrollmentResponseDto
            {
                Id = enrollment.Id,
                ClassId = enrollment.ClassId,
                StudentId = enrollment.StudentId,
                EnrollmentDate = enrollment.EnrollmentDate,
                EnrollmentNumber = enrollment.EnrollmentNumber
            };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateEnrollmentDto enrollmentDto)
    {
        try
        {
            var e = new Enrollment
            {
                Id = id,
                Status = enrollmentDto.Status
            };
            return Ok(e);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("student/{studentId}")]
public async Task<ActionResult> GetByStudentId(int studentId)
{
    var enrollments = await _enrollmentsService.GetByStudentAsync(studentId);

    return Ok(enrollments);
}
}
