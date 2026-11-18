using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necessário para usar .ToListAsync()
using GestaoIgreja.Data;
using GestaoIgreja.Models;
using GestaoIgreja.DTOs;

namespace GestaoIgreja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoacaoController(AppDbContext context)
        {
            _context = context;
        }

        // Rota POST: /api/doacao
        [HttpPost]
        public async Task<IActionResult> RegistrarDoacao([FromBody] DoacaoRequestDto dto)
        {
            // 1. Converte o DTO para o Model verdadeiro
            var novaDoacao = new Doacao
            {
                Valor = dto.Valor,
                Categoria = dto.Categoria,
                ComprovanteUrl = dto.ComprovanteUrl,
                IdUsuario = dto.IdUsuario,
                IdIgreja = dto.IdIgreja,
                Data = DateTime.Now,
                Status = "Pendente"
            };

            // 2. Salva no banco de dados MySQL
            _context.Doacoes.Add(novaDoacao);
            await _context.SaveChangesAsync();

            // 3. Devolve sucesso para o Front-end
            return Ok(new { mensagem = "Doação registrada com sucesso!" });
        }

        // Rota GET: /api/doacao/usuario/{idUsuario}
        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ObterDoacoesPorUsuario(int idUsuario)
        {
            // Busca no banco todas as doações do usuário informado
            var doacoes = await _context.Doacoes
                .Where(d => d.IdUsuario == idUsuario)
                .ToListAsync();

            // Retorna a lista de doações encontradas (mesmo que vazia)
            return Ok(doacoes);
        }

        // Rota GET: /api/doacao/igreja/{idIgreja}
        [HttpGet("igreja/{idIgreja}")]
        public async Task<IActionResult> ObterDoacoesPorIgreja(int idIgreja)
        {
            // Busca no banco todas as doações onde o IdIgreja corresponda ao informado na rota
            var doacoes = await _context.Doacoes
                .Where(d => d.IdIgreja == idIgreja)
                .ToListAsync();

            // Retorna a lista completa de doações daquela igreja
            return Ok(doacoes);
        }
    }
}