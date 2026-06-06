
using LanguageSchool.Data;
using LanguageSchool.Repository.Implementations;
using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Services;
using LanguageSchool.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
var jwtKey = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey!)
        )
    };
});

builder.Services.AddAuthorization();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();

