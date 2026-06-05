using LanguageSchool.DTOs.Guardians;
using LanguageSchool.Models;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuardiansController : ControllerBase
{
    public IGuardiansService _guardiansService;
    public GuardiansController(IGuardiansService guardiansService)
    {
        this._guardiansService = guardiansService;
    }

    [HttpGet]
    public async Task<ActionResult>Get()
    {
        var guardians = await _guardiansService.GetAllGuardiansAsync();
        return Ok(guardians);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var guardian = await _guardiansService.GetByIdAsync(id);
        return Ok(guardian);
    }
    [HttpPost]
    public async Task<ActionResult> Create(CreateGuardianDto dto)
    {
        var guardian = new Guardian
        {
            Name = dto.Name,
            StudentId = dto.StudentId,
            Phone = dto.Phone,
            Email = dto.Email
        };
        var createdGuardian = await _guardiansService.CreateGuardianAsync(guardian);
        return Ok(createdGuardian);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _guardiansService.DeleteGuardianAsync(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, UpdateGuardianDto dto)
    {
        var guardian = new Guardian
        {
            Name = dto.Name,
            StudentId = dto.StudentId,
            Phone = dto.Phone,
            Email = dto.Email
        };
        var updatedGuardian = await _guardiansService.UpdateGuardianAsync(id, guardian);
        return Ok(updatedGuardian);
    }
   
}