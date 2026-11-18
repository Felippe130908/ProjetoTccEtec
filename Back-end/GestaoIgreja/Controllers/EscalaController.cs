using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data;
using GestaoIgreja.Models;
using GestaoIgreja.DTOs;

namespace GestaoIgreja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscalaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EscalaController(AppDbContext context)
        {
            _context = context;
        }

        // Rota POST: /api/Escala (Criar escala para um ministério em um evento)
        [HttpPost]
        public async Task<IActionResult> CriarEscala([FromBody] EscalaRequestDto dto)
        {
            var novaEscala = new Escala
            {
                NomeMinisterio = dto.NomeMinisterio,
                IdEvento = dto.IdEvento
            };

            _context.Escalas.Add(novaEscala);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Escala criada com sucesso!", id = novaEscala.IdEscala });
        }

        // Rota POST: /api/Escala/participante (Escalar um membro na escala)
        [HttpPost("participante")]
        public async Task<IActionResult> AdicionarParticipante([FromBody] ParticipacaoEscalaRequestDto dto)
        {
            var participacao = new ParticipacaoEscala
            {
                IdUsuario = dto.IdUsuario,
                IdEscala = dto.IdEscala,
                Status = dto.Status
            };

            _context.ParticipacoesEscalas.Add(participacao);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Membro adicionado à escala com sucesso!" });
        }

        // Rota GET: /api/Escala/evento/1 (Listar escalas e voluntários de um evento)
        [HttpGet("evento/{idEvento}")]
        public async Task<IActionResult> ListarPorEvento(int idEvento)
        {
            var escalas = await _context.Escalas
                .Where(e => e.IdEvento == idEvento)
                .Select(e => new
                {
                    e.IdEscala,
                    e.NomeMinisterio,
                    e.IdEvento,
                    Voluntarios = e.ParticipacoesEscalas.Select(p => new
                    {
                        p.IdUsuario,
                        NomeVoluntario = p.Usuario.Nome,
                        p.Status
                    })
                })
                .ToListAsync();

            return Ok(escalas);
        }
    }
}