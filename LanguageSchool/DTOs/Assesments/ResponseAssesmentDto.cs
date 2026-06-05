namespace LanguageSchool.DTOs.Assesments;

public class ResponseAssesmentDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string Title { get; set; }
    public decimal MaxScore{get; set;}
}
