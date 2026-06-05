using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageSchool.Repository.Implementations;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AppDbContext _context;

    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Enrollment> CreateAsync(Enrollment enrollment)
    {
            
        await _context.enrollments.AddAsync(enrollment);
        await _context.SaveChangesAsync();

        return enrollment;
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        return await _context.enrollments.ToListAsync();
    }

    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _context.enrollments.FindAsync(id);
    }

    public async Task UpdateAsync(Enrollment enrollment)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Enrollment enrollment)
    {
        _context.enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int studentId, int classId)
    {
        return await _context.enrollments
            .AnyAsync(e =>
                e.StudentId == studentId &&
                e.ClassId == classId);
    }

    public async Task<int> CountByClassIdAsync(int classId)
    {
        return await _context.enrollments
            .CountAsync(e => e.ClassId == classId);
    }
       public Task<List<Enrollment>> GetByStudentAsync(int studentId)
    {
        return _context.enrollments
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }
}