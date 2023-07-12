using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;
using AutoMapper;
using TicTacToe.Interfaces;
using TicTacToe.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using TicTacToe.Models.Users;
using TicTacToe.Validators;
using TicTacToe.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<UserCreate>, UserCreateValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameContext>(opt => opt.UseSqlServer(builder.Configuration["DbConnectionString"]));

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
