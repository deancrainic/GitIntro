//using HakunaMatata.Application.Commands;
//using HakunaMatata.Application.Queries;
using HakunaMatata.Application.Commands;
using HakunaMatata.Core.Abstractions;
using HakunaMatata.Data;
using HakunaMatata.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateUserCommand));

//Database
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<HakunaMatataContext>(options => options.UseSqlServer(cs), ServiceLifetime.Singleton);

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
