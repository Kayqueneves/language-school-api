using LanguageSchool.Models;
namespace LanguageSchool.Services.Interfaces;
public interface IStudentGradesService 
{
    Task <List<StudentGrade>> GetAllAsync();
    Task <StudentGrade> GetByIdAsync(int id);
    Task <StudentGrade> PostAsync(StudentGrade studentGrades);
    Task <StudentGrade> UpdateAsync(int id, StudentGrade studentGrades);
}
