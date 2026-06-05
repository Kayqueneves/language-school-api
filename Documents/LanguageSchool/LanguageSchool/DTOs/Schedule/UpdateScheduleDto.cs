namespace LanguageSchool.DTOs.Schedule;

public class UpdateScheduleDto
{
    public string DayOfWeek { get; set; } = string.Empty;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
