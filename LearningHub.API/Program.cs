using LearningHub.core.Common;
using LearningHub.core.Repository;
using LearningHub.core.Service;
using LearningHub.infra.Common;
using LearningHub.infra.Repository;
using LearningHub.infra.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Database Scope
builder.Services.AddScoped<IDbContext, DbContext>();
//Repository Scope
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStdCourseRepository, StdCourseRepository>();
builder.Services.AddScoped<IDisplayStudentRepository, DisplayStudentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
//Service Scope
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStdCourseService, StdCourseService>();
builder.Services.AddScoped<ICategoryService,  CategoryService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
