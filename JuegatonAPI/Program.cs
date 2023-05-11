using Dapper;
using JuegatonAPI.Repositories;
using JuegatonAPI.Models;
using Microsoft.EntityFrameworkCore;

DefaultTypeMap.MatchNamesWithUnderscores = true;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PosgreSQLConfig>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("JuegatonDB")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton(builder.Services.AddDbContext<PosgreSQLConfig>(options =>
    options.UseSqlServer("JuegatonDB")));

builder.Services.AddScoped<JugadorRepository>();
builder.Services.AddScoped<WordleRepository>();
builder.Services.AddScoped<AhorcadoRepository>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("https://juegatonweb.azurewebsites.net/") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Nueva Politica");
app.UseAuthorization();

app.MapControllers();

app.Run();

