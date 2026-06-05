using LanguageSchool.Models;
using LanguageSchool.Enums;
namespace LanguageSchool.Services.Interfaces;

public interface IEnrollmentsService
{
    Task <List<Enrollment>> GetAllAsync();
    Task <Enrollment> GetByIdAsync(int id);

    Task <Enrollment> CreateAsync(int classId, int studentId);
    Task <Enrollment> UpdateStatusAsync(int id, EnrollmentStatus status);
    Task DeleteAsync(int id);
    Task<List<Enrollment>> GetByStudentAsync(int studentId);

}
