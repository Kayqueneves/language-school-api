using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.DTOs.Schedule;
using LanguageSchool.Models;

namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var schedules = await _scheduleService.GetAllAsync();
        return Ok(schedules);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var schedule = await _scheduleService.GetByIdAsync(id);

        if (schedule == null)
            return NotFound();

        return Ok(schedule);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateScheduleDto dto)
    {
        var schedule = new Schedule
        {
            DayOfWeek = dto.DayOfWeek,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime
        };

        var createdSchedule = await _scheduleService.CreateAsync(schedule);

        return Ok(createdSchedule);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateScheduleDto dto)
    {
        var scheduleToUpdate = new Schedule
        {
            DayOfWeek = dto.DayOfWeek,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime
        };

        var updatedSchedule = await _scheduleService.UpdateAsync(id, scheduleToUpdate);

        return Ok(updatedSchedule);
    }
}