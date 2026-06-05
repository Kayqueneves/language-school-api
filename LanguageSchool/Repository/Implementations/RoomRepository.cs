using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Data;
using Microsoft.EntityFrameworkCore;

namespace LanguageSchool.Repository.Implementations;

public class RoomRepository : IRoomRepository
{
    readonly AppDbContext _context;
    public RoomRepository(AppDbContext context)
    {
        this._context = context;
    }
    public async Task<Room> CreateAsync(Room room)
    {
        _context.rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task DeleteAsync(int id)
    {
        _context.rooms.Remove(_context.rooms.Find(id));
        await _context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetAllAsync()
    {

        return _context.rooms.ToList();

    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _context.rooms.FindAsync(id);
    }

    public  Task<Room?> GetByNameAsync(string name)
    {
        return  _context.rooms.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Room> UpdateAsync(int id, Room room)
    {
        _context.rooms.Update(room);
        await _context.SaveChangesAsync();
        return room;
    }

}
