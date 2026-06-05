using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class StudentGrade
{
    public int Id { get; set; }
    [Column("student_id")]
    public int StudentId { get; set; }
    
    [Column("score")]
    public decimal Score { get; set; }
    [Column("assesment_id")]
    public int AssesmentId{get; set;}
}
