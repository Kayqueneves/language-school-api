namespace LanguageSchool.DTOs.StudentGrades;

public class ResponseStudentGradeDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int AssesmentId { get; set; }
    public decimal Score { get; set; }
}
