using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Server;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CourseEnrollmentDB"));

builder.Services.AddControllers();

// Enable CORS for Client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
        policy => policy
            .WithOrigins("https://localhost:7099", "https://localhost:7202") //<-- Client URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();  
app.Run();

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
