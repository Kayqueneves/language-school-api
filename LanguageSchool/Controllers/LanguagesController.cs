using Microsoft.AspNetCore.Mvc;
using LanguageSchool.Services.Interfaces;
using LanguageSchool.Models;
using LanguageSchool.DTOs.Courses;
using LanguageSchool.Services;
using LanguageSchool.DTOs.Languages;
namespace LanguageSchool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguagesController : ControllerBase
{
    readonly ILanguagesService _languageService;
    public LanguagesController(ILanguagesService languageService)
    {
        this._languageService = languageService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var languages = await _languageService.GetAllAsync();
        return Ok(languages);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var language = await _languageService.GetByIdAsync(id);
        return Ok(language);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateLanguageDto dto)
    {
        var language = new Language
        {
            Name = dto.Name
        };
        var createdLanguage = await _languageService.CreateAsync(language);
        return Ok(createdLanguage);
    }
}
