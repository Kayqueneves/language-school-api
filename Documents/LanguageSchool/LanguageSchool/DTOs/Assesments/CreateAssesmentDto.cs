namespace LanguageSchool.DTOs.Assesments;

public class CreateAssessmentDto
{
    public int ClassId { get; set; }
    public string Title { get; set; }
    public decimal MaxScore{get; set;}
}
