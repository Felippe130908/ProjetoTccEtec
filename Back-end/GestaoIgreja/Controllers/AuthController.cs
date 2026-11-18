using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data;
using GestaoIgreja.DTOs;

namespace GestaoIgreja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // Rota POST: /api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Cargo)
                .FirstOrDefaultAsync(u => u.Email == dto.Email && u.SenhaHash == dto.Senha && u.Ativo);

            if (usuario == null)
            {
                return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });
            }

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                usuario = new
                {
                    usuario.IdUsuario,
                    usuario.Nome,
                    usuario.Email,
                    usuario.IdIgreja,
                    usuario.IdCargo,
                    Cargo = usuario.Cargo?.Nome
                }
            });
        }
    }
}