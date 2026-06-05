using LanguageSchool.Models;

namespace LanguageSchool.DTOs.Courses;
public class UpdateCourseDto
{
    
    public string Name { get; set; }
    public string Level { get; set; }
    public int LanguageId { get; set; } 
}
