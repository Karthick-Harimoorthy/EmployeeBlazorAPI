
using EmployeeBlazorAPI;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string MyAllowSPecificOrigins = "_MyAllowSPecificOrigins";
builder.Services.AddCors(options => {

    options.AddPolicy("_MyAllowSPecificOrigins", builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("EmployeeDBContext"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSPecificOrigins);

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.Run();

