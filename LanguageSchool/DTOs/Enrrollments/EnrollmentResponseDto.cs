namespace AssessmentDbService.DTOs.Enrrollments;

public class EnrollmentResponseDto
{
  public int Id { get; set; }
  public int StudentId { get; set; }
  public int ClassId { get; set; }
  public DateTime EnrollmentDate { get; set; }
  public string EnrollmentNumber { get; set; }

}
