
using LanguageSchool.Data;
using LanguageSchool.Models;
using LanguageSchool.Repository.Implementations;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentsService, StudentDbService>();
builder.Services.AddScoped<ITeachersService, TeacherDbService>(); 
builder.Services.AddScoped<IClassesService, ClassesDbService>();
builder.Services.AddScoped<ICoursesService, CourseDbService>();
builder.Services.AddScoped<IAssesmentService, AssesmentDbService>();
builder.Services.AddScoped<IEnrollmentsService, EnrollmentDbService>();
builder.Services.AddScoped<IGuardiansService, GuardianDbService>();
builder.Services.AddScoped<ILanguagesService, LanguagesDbService>();
builder.Services.AddScoped<IScheduleService, ScheduleDbService>();
builder.Services.AddScoped<IRoomService, RoomDbService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IStudentGradesService, StudentGradesDbService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();

