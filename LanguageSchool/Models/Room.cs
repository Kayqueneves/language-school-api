using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class Room
{
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("capacity")]
    public int Capacity { get; set; }
    [Column("description")]
    public string? Description { get; set; }
}
