using System.ComponentModel.DataAnnotations.Schema;
using LanguageSchool.Enums;
namespace LanguageSchool.Models;

public class Enrollment
{
    public int Id { get; set; }
    [Column("student_id")]
    public int StudentId { get; set; } 
    [Column("class_id")]
    public int ClassId { get; set; } 
    [Column("enrollment_date")]
    public DateTime EnrollmentDate { get; set; }
    [Column("enrollment_number")]
    public string EnrollmentNumber { get; set; }
    public EnrollmentStatus Status { get; set; }

}
