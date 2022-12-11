using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Services;
{
    
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(op =>op.UseNpgsql(connection));

builder.Services.AddControllers();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<JobHistoryService>();
builder.Services.AddScoped<JobGradeService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<RegionService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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