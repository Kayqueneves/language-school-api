using LanguageSchool.Models;
namespace LanguageSchool.Repository.Interfaces;

public interface IRoomRepository
{
    public Task<Room> CreateAsync(Room room);
    public Task<Room> GetByIdAsync(int id);
    public Task<List<Room>> GetAllAsync();
    public Task DeleteAsync(int id);
    public Task<Room> UpdateAsync(int id, Room room);
    public Task<Room> GetByNameAsync(string name);
}
