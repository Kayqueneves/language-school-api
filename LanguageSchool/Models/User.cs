using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class User
{
    public int Id { get; set; }
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;
    [Column("role")]
    public string Role { get; set; } = "User";
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}