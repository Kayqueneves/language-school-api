using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;

public interface IRoomService
{
    Task<List<Room>>GetAllAsync();
    Task<Room?> GetByIdAsync(int id);
    Task<Room> CreateAsync(Room room);
    Task DeleteAsync(int id);
    Task<Room> UpdateAsync(int id, Room room);
    Task<Room?> GetByNameAsync(string name);
}
