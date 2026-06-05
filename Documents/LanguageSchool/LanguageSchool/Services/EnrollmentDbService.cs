using LanguageSchool.Enums;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services.Interfaces;

namespace LanguageSchool.Services;

public class EnrollmentDbService : IEnrollmentsService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IStudentsService _studentService;
    private readonly IRepository<SchoolClass> _classRepository;

    public EnrollmentDbService(
    IEnrollmentRepository enrollmentRepository,
    IStudentsService studentService,
    IRepository<SchoolClass> classRepository)
{
    _enrollmentRepository = enrollmentRepository;
    _studentService = studentService;
    _classRepository = classRepository;
}

public async Task<Enrollment> CreateAsync(int studentId, int classId)
{
  Console.WriteLine($"studentId recebido: {studentId}");

var allStudents = await _studentService.GetAllStudentsAsync();

Console.WriteLine($"Total students: {allStudents.Count}");

foreach (var s in allStudents)
{
    Console.WriteLine($"Student: {s.Id} - {s.Name}");
}

var student = await _studentService.GetByIdAsync(studentId);

    Console.WriteLine($"classId recebido: {classId}");

    var classEntity = await _classRepository.GetByIdAsync(classId);

    Console.WriteLine(classEntity == null
        ? "Class NULL"
        : $"Class encontrada: {classEntity.Id}");

    if (classEntity == null)
        throw new Exception("Class not found");

    var alreadyEnrolled =
        await _enrollmentRepository.ExistsAsync(studentId, classId);

    if (alreadyEnrolled)
        throw new Exception("Student already enrolled");

    var currentStudents =
        await _enrollmentRepository.CountByClassIdAsync(classId);

    if (currentStudents >= classEntity.MaxStudents)
        throw new Exception("Class is full");

    var enrollment = new Enrollment
    {
        StudentId = studentId,
        ClassId = classId,
        EnrollmentDate = DateTime.UtcNow,
        EnrollmentNumber = $"ENR-{Guid.NewGuid().ToString("N")[..8].ToUpper()}",
        Status = EnrollmentStatus.Active
    };

    return await _enrollmentRepository.CreateAsync(enrollment);
}


    public async Task DeleteAsync(int id)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);

        if (enrollment == null)
            throw new Exception("Enrollment not found");

        await _enrollmentRepository.DeleteAsync(enrollment);
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        return await _enrollmentRepository.GetAllAsync();
    }

    public async Task<Enrollment> GetByIdAsync(int id)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);

        if (enrollment == null)
            throw new Exception("Enrollment not found");

        return enrollment;
    }

    public Task<List<Enrollment>> GetByStudentAsync(int studentId)
    {
        return _enrollmentRepository.GetByStudentAsync(studentId);
    }


    public async Task<Enrollment> UpdateStatusAsync(int id, EnrollmentStatus status)
{
    var existingEnrollment = await _enrollmentRepository.GetByIdAsync(id);

    if (existingEnrollment == null)
        throw new Exception("Enrollment not found");

    existingEnrollment.Status = status;

    await _enrollmentRepository.UpdateAsync(existingEnrollment);

    return existingEnrollment;
}
    }


