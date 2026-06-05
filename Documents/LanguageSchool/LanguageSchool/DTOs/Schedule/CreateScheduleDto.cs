namespace LanguageSchool.DTOs.Schedule;

public class CreateScheduleDto
{
    public string DayOfWeek { get; set; } 
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
