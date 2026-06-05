using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    [Column("language_id")]
    public int LanguageId { get; set; } // Foreign key to the Languages table
}
