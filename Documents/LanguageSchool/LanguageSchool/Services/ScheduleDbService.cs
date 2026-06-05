using LanguageSchool.Services.Interfaces;
using LanguageSchool.Repository.Interfaces;
namespace LanguageSchool.Services;
using LanguageSchool.Models;

public class ScheduleDbService : IScheduleService
{
    private readonly IRepository<Schedule> _repository;

    public ScheduleDbService(IRepository<Schedule> repository)
    {
        _repository = repository;
    }
    public async Task<Schedule> CreateAsync(Schedule schedule)
    {
        var createdSchedule = await _repository.CreateAsync(schedule);
        return createdSchedule;
    }

    public async Task DeleteAsync(int id)
    {
        var schedule = await _repository.GetByIdAsync(id);
       if(schedule == null)
        {
            throw new Exception("Schedule not found");
        }
        await _repository.DeleteAsync(id);
    }

    public async Task<List<Schedule>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Schedule> GetByIdAsync(int id)
    {
        var schedule = await _repository.GetByIdAsync(id);
        if(schedule == null){
            throw new Exception("Schedule not found");
        
        }
         return schedule;
    }


    public async Task<Schedule> UpdateAsync(int id, Schedule schedule)
    {
        var 
       existingSchedule = await _repository.GetByIdAsync(id);
        if(existingSchedule == null)
        {
            throw new Exception("Schedule not found");
        }
        existingSchedule.DayOfWeek = schedule.DayOfWeek;
        existingSchedule.StartTime = schedule.StartTime;
        existingSchedule.EndTime = schedule.EndTime;
        var updatedSchedule = await _repository.UpdateAsync(id, existingSchedule);
        return updatedSchedule;
    }


}