using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PRACTICA_WEB_API_LIBROS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Inyeccion por dependencia de la base de datos
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(
             builder.Configuration.GetConnectionString("librosDbConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
