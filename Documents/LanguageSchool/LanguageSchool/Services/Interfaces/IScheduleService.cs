using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface IScheduleService
{
    Task<Schedule> CreateAsync(Schedule schedule);
    Task<Schedule> GetByIdAsync(int id);
    Task<List<Schedule>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<Schedule> UpdateAsync(int id, Schedule schedule);
}
