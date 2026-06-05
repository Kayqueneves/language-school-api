using LanguageSchool.Models;
namespace LanguageSchool.Repository.Interfaces;

public interface IScheduleRepository
{
    Task<Schedule> CreateAsync(Schedule schedule);
    Task<Schedule?> GetByIdAsync(int id);
    Task<List<Schedule>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<Schedule> UpdateAsync(int id, Schedule schedule);
}
