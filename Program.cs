using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WebMusicContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IGenresService, GenresService>();
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
