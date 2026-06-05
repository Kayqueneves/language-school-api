using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.Models;
using LanguageSchool.DTOs.Rooms;
namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    readonly IRoomService _roomService;
    public RoomController(IRoomService roomService)
    {
        this._roomService = roomService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(rooms);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateRoomDto dto)
    {
        var room = new Room
        {
            Name = dto.Name,
            Capacity = dto.Capacity
        };
        var createdRoom = await _roomService.CreateAsync(room);
        return Ok(createdRoom);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateRoomDto dto)
    {
        var room = new Room
        {
            Name = dto.Name,
            Capacity = dto.Capacity
        };
        var updatedRoom = await _roomService.UpdateAsync(id, room);
        return Ok(updatedRoom);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)        {
            return NotFound();
        }
        await _roomService.DeleteAsync(id);
        return NoContent();
    }
}
