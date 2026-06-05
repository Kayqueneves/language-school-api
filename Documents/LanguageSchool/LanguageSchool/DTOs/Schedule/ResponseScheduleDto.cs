namespace LanguageSchool.DTOs.Schedule;

public class ResponseScheduleDto
{
    public int Id { get; set; }
    public string DayOfWeek { get; set; } 
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
