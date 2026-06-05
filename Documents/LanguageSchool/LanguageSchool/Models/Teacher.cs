using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;
public class Teacher
{
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("specialty")]
    public string Specialty { get; set; }
}

