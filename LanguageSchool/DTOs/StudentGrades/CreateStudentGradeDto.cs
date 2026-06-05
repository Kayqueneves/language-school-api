namespace LanguageSchool.DTOs.StudentGrades;

public class CreateStudentGradeDto
{
    public int StudentId { get; set; }
    public int AssesmentId { get; set; }
    public decimal Score { get; set; }
}
