using TextilesGeomar.API.Services.Interfaces;
using TextilesGeomar.API.Services;
using TextilesGeomar.API.DTOs;
using TextilesGeomar.API.Mappers.Interfaces;
using TextilesGeomar.API.Mappers;
using TextilesGeomar.API.Models;
using TextilesGeomar.API.Repositories.Interfaces;
using TextilesGeomar.API.Repositories;
using Microsoft.EntityFrameworkCore;
using TextilesGeomar.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your DbContext
builder.Services.AddDbContext<TextilesGeomarDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your UserService for dependency injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMapper<User, UserDTO>, UserMapper>();

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
