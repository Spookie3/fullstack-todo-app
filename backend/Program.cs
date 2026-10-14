using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDo.Data;
using ToDo.Endpoints;
using ToDo.Services;

var builder = WebApplication.CreateBuilder(args);

// Register EF core with SQLite, using connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register TodoService

builder.Services.AddScoped<InterfaceTodoService, TodoService>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Endpoints
app.MapTodoEndpoints();

app.Run();