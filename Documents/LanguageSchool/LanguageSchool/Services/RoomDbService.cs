using System.ComponentModel;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;
namespace LanguageSchool.Services;

public class RoomDbService : IRoomService
{
    readonly  IRoomRepository _repository;
    public RoomDbService(IRoomRepository repository)
    {
        this._repository = repository;
    }
    public async Task<Room> CreateAsync(Room room)
    {
        var existingRoom = await _repository.GetByNameAsync(room.Name);
        if (existingRoom != null)
        {
            throw new Exception("Room already exists");
        }
        return await _repository.CreateAsync(room);
    }

    public async Task DeleteAsync(int id)
    {
        var room = await _repository.GetByIdAsync(id);
        if (room == null)
        {
            throw new Exception("Room not found");
        }
        await _repository.DeleteAsync(id); 
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        var room = await _repository.GetByIdAsync(id);
        if (room == null)
        {
            throw new Exception("room not found");
        }
        return room;
    }

    public async Task<Room> GetByNameAsync(string name)
    {
        var room = await _repository.GetByNameAsync(name);
        if (room == null)
        {
            throw new Exception("Room not found");
        }
        return room;
    }

    public async Task<Room> UpdateAsync(int id, Room room)
    {
        var r = await _repository.GetByIdAsync(id);
        if (r == null)
        {
            throw new Exception("Room not found");
        };

        r.Name = room.Name;
        r.Capacity = room.Capacity;
        r.Description = room.Description;

        var updated = await _repository.UpdateAsync(id, r);
        return updated;
    }

}
