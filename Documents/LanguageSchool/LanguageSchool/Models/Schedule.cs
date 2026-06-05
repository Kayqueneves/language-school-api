using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

public class Schedule
{
    public int Id { get; set; }
    [Column("day_of_week")]
    public string DayOfWeek { get; set; } 
    [Column("start_time")]
    public TimeSpan StartTime { get; set; }

    [Column("end_time")]
    public TimeSpan EndTime { get; set; }


}
