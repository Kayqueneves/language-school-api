namespace LanguageSchool.DTOs.Assesments;

public class UpdateAssessementDto
{
  
    public int ClassId { get; set; }
    public string Title { get; set; }
    public decimal MaxScore{get; set;} 
}
