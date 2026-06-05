using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class Student    
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Level { get; set; }
    [Column("registration_number")]
    public string RegistrationNumber { get; set; }
}
