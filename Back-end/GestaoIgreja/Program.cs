using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data; // Importa a pasta onde está o AppDbContext

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// 1. CONFIGURAÇÃO DO BANCO DE DADOS (MySQL)
// ============================================================
// Vai lá no appsettings.json e pega a senha e o nome do banco
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Avisa ao C# para usar o AppDbContext com o MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ============================================================
// 2. CONFIGURAÇÃO DOS SERVIÇOS DA API
// ============================================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Gera a interface visual para testarmos a API

var app = builder.Build();

// ============================================================
// 3. CONFIGURAÇÃO DO FLUXO (PIPELINE)
// ============================================================
// Ativa o Swagger (página de testes) quando estivermos programando
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication(); // Descomentaremos isso quando fizermos o Login
app.UseAuthorization();

app.MapControllers();

app.Run();