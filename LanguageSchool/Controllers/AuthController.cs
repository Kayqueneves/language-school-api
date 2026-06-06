using Microsoft.AspNetCore.Mvc;
using LanguageSchool.DTOs.Login;
using LanguageSchool.DTOs.Register;
using LanguageSchool.Models;
using LanguageSchool.Services;
using LanguageSchool.Repository.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IUserRepository _userRepository;

    public AuthController(AuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

[HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto dto)
{
    var userExists = await _userRepository.GetByEmailAsync(dto.Email);

    if(userExists != null)
        return BadRequest("User already exists");

    var user = new User
    {
        Email = dto.Email,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        Role = "User"
    };

    await _userRepository.CreateAsync(user);

    return Ok("User created successfully");
}
[HttpPost("login")]
public async Task<IActionResult> Login(LoginDto dto)
{
    var user = await _userRepository.GetByEmailAsync(dto.Email);

    if (user == null)
        return Unauthorized("email or password is incorrect");

    var passwordValid = BCrypt.Net.BCrypt.Verify(
        dto.Password,
        user.PasswordHash
    );

    if (!passwordValid)
        return Unauthorized("email or password is incorrect");

    var token = _authService.GenerateToken(user.Email, user.Role);

    return Ok(new
    {
        token
    });
}
    
}