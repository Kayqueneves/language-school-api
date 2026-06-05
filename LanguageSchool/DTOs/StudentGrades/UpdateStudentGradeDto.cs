namespace LanguageSchool.DTOs.StudentGrades;

public class UpdateStudentGradeDto
{
    public int StudentId { get; set; }
    public int AssesmentId { get; set; }
    public decimal Score { get; set; }
}
