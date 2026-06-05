using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class Guardian
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
     [Column("student_id")]
    public int StudentId { get; set; }
    
}
