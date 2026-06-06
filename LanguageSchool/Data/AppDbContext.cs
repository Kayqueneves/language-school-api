using Microsoft.EntityFrameworkCore;
using LanguageSchool.Models;
namespace LanguageSchool.Data;

public class AppDbContext :   DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Student> students { get; set; }
    public DbSet<Course> courses { get; set; }
    public DbSet<Enrollment> enrollments { get; set; }
    public DbSet<Teacher> teachers { get; set; }
    public DbSet<Language> languages { get; set; }
    public DbSet<SchoolClass> school_classes { get; set; }
    public DbSet<Guardian> guardians { get; set; }
    public DbSet<Assessment> assessments { get; set; }
    public DbSet<StudentGrade> student_grades { get; set; }
    public DbSet<TeacherLanguages> teacher_languages { get; set; }
    public DbSet<Room> rooms { get; set; }
    public DbSet<Schedule> schedules { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("students");
        modelBuilder.Entity<Course>().ToTable("courses");
        modelBuilder.Entity<Enrollment>().ToTable("enrollments");
        modelBuilder.Entity<Teacher>().ToTable("teachers");
        modelBuilder.Entity<Language>().ToTable("languages");
        modelBuilder.Entity<SchoolClass>().ToTable("school_classes");
        modelBuilder.Entity<Guardian>().ToTable("guardians");
        modelBuilder.Entity<Assessment>().ToTable("assesments");
        modelBuilder.Entity<StudentGrade>().ToTable("student_grades");
        modelBuilder.Entity<TeacherLanguages>().ToTable("teacher_languages");
        modelBuilder.Entity<Room>().ToTable("rooms");
        modelBuilder.Entity<Schedule>().ToTable("schedules");
        modelBuilder.Entity<User>().ToTable("users");
    }

}
