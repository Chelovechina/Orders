using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Interfaces;
using Orders.DAL.Repositories;
using Orders.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conecting DB
var connection = builder.Configuration.GetSection("DB").Value;
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IRepository<Item>, ItemRepository>();

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
