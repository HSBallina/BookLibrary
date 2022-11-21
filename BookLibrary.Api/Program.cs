using BookLibrary.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BookLibrary.Data.Models;
using BookLibrary.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
  .AddJsonOptions(o => o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddDbContext<BookDbContext>(opt
  => opt.UseSqlServer(builder.Configuration.GetConnectionString("BookLibrary")));

builder.Services.AddAutoMapper(typeof(Book).Assembly);
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
