using Microsoft.AspNetCore.SignalR;
using LanguageSchool.Models;

namespace LanguageSchool.Services.Interfaces;

public interface IStudentsService
{
    Task <Student> CreateAsync(Student student);
    Task <Student> GetByIdAsync(int id);
    Task DeleteStudentAsync(int id);
    Task <Student> UpdateStudentAsync(int id, Student student);
    Task <List<Student>> GetAllStudentsAsync();
}
