using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// 1. CONFIGURAÇÃO DO BANCO DE DADOS (MySQL)
// ============================================================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ============================================================
// 2. CONFIGURAÇÃO DOS SERVIÇOS DA API E CORS
// ============================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ============================================================
// 3. CONFIGURAÇÃO DO FLUXO (PIPELINE)
// ============================================================
app.UseSwagger();
app.UseSwaggerUI();

// Ativa o CORS antes da autorização e das rotas
app.UseCors("PermitirFrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();