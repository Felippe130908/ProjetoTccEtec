using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data;
using GestaoIgreja.Models;
using GestaoIgreja.DTOs;

namespace GestaoIgreja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembroController(AppDbContext context)
        {
            _context = context;
        }

        // Rota POST: /api/Membro (Cadastrar membro)
        [HttpPost]
        public async Task<IActionResult> CadastrarMembro([FromBody] MembroRequestDto dto)
        {
            var novoMembro = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = dto.Senha,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                Telefone = dto.Telefone,
                IdCargo = dto.IdCargo,
                IdIgreja = dto.IdIgreja,
                Ativo = true
            };

            _context.Usuarios.Add(novoMembro);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Membro cadastrado com sucesso!", id = novoMembro.IdUsuario });
        }

        // Rota GET: /api/Membro/igreja/1 (Listar membros da igreja)
        [HttpGet("igreja/{idIgreja}")]
        public async Task<IActionResult> ListarPorIgreja(int idIgreja)
        {
            var membros = await _context.Usuarios
                .Where(u => u.IdIgreja == idIgreja && u.Ativo)
                .Select(u => new
                {
                    u.IdUsuario,
                    u.Nome,
                    u.Email,
                    u.Telefone,
                    u.IdCargo,
                    u.Ativo
                })
                .ToListAsync();

            return Ok(membros);
        }
    }
}