using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageSchool.Models;

[Table("school_classes")]
public class SchoolClass
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("schedule_id")]
    public int ScheduleId { get; set; }

    [Column("room_id")]
    public int RoomId { get; set; }

    [Column("max_students")]
    public int MaxStudents { get; set; }
}
