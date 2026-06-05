namespace LanguageSchool.DTOs.Classes;

public class CreateClassDto
{
    public int CourseId { get; set; } 
    public int TeacherId { get; set; } 
    public int ScheduleId { get; set; } 
    public int RoomId { get; set; } 
        public int MaxStudents { get; set; }
}
