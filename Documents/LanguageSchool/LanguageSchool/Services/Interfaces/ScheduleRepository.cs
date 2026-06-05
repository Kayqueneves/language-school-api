using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
namespace LanguageSchool.Services.Interfaces;

public class ScheduleRepository : IScheduleRepository
{
    readonly IScheduleRepository _scheduleRepository;
    public ScheduleRepository(IScheduleRepository scheduleRepository)
    {
        this._scheduleRepository = scheduleRepository;
    }
    public Task<Schedule> CreateAsync(Schedule schedule)
    {
        return _scheduleRepository.CreateAsync(schedule);
    }

    public Task DeleteAsync(int id)
    {
        return _scheduleRepository.DeleteAsync(id);
    }

    public Task<List<Schedule>> GetAllAsync()
    {
        return _scheduleRepository.GetAllAsync();
    }

    public Task<Schedule?> GetByIdAsync(int id)
    {
        return _scheduleRepository.GetByIdAsync(id);
    }

    public Task<Schedule> UpdateAsync(int id, Schedule schedule)
    {
        return _scheduleRepository.UpdateAsync(id, schedule);
    }

}
