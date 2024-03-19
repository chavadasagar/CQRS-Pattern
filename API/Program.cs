using API.Configuration;
using Application;
using Domain.Catalog;
using Infrastrcture;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.AddConfigurations();
builder.Services.AddApplication();
builder.Services.AddInfrastrcture(builder.Configuration);

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


//--Employee table
//CREATE TABLE Employee (
//    employee_id INT PRIMARY KEY,
//    name VARCHAR(100) NOT NULL,
//    email VARCHAR(100) UNIQUE,
//    department VARCHAR(50),
//    position VARCHAR(50)
//);

//--Task table
//CREATE TABLE Task (
//    task_id INT PRIMARY KEY,
//    task_description VARCHAR(255) NOT NULL,
//assigned_to INT,
//    deadline DATE,
//status VARCHAR(20),
//    FOREIGN KEY (assigned_to) REFERENCES Employee(employee_id)
//);


//--EXEC sp_rename 'Employee.employee_id', 'id', 'COLUMN';

//--EXEC sp_rename 'Task.task_id', 'id', 'COLUMN';

//ALTER TABLE Task
//RENAME COLUMN task_id TO id;


