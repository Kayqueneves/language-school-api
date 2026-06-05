using LanguageSchool.Models;
namespace LanguageSchool.Repository.Interfaces;
public interface IEnrollmentRepository
{
  Task<Enrollment> CreateAsync(Enrollment enrollment);
Task<Enrollment?> GetByIdAsync(int id);
Task<List<Enrollment>> GetAllAsync();
Task DeleteAsync(Enrollment enrollment);
Task UpdateAsync(Enrollment enrollment);
Task<bool> ExistsAsync(int studentId, int classId);
  Task<int> CountByClassIdAsync(int classId);
Task<List<Enrollment>> GetByStudentAsync(int studentId);
}
