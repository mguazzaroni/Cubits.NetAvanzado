using Cubits.NET.Avanzado.Application;
using Cubits.NET.Avanzado.Infastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("Default", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Levanto servicios de la capa de aplicación
builder.Services.AddApplication();
// Levanto servicios de la capa de infraestructura
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Cubits"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
    
app.UseAuthorization();

app.UseCors("Default");

app.MapControllers();

app.Run();
