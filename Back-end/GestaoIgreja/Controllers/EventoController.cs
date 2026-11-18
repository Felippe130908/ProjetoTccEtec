using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Data;
using GestaoIgreja.Models;
using GestaoIgreja.DTOs;

namespace GestaoIgreja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoController(AppDbContext context)
        {
            _context = context;
        }

        // Rota POST: /api/Evento
        [HttpPost]
        public async Task<IActionResult> RegistrarEvento([FromBody] EventoRequestDto dto)
        {
            var novoEvento = new Evento
            {
                Titulo = dto.Nome,
                Descricao = dto.Descricao,
                DataHora = dto.DataEvento,
                IdIgreja = dto.IdIgreja
            };

            _context.Eventos.Add(novoEvento);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Evento registrado com sucesso!" });
        }

        // Rota GET: /api/Evento/igreja/1
        [HttpGet("igreja/{idIgreja}")]
        public async Task<IActionResult> ObterEventosPorIgreja(int idIgreja)
        {
            var eventos = await _context.Eventos
                .Where(e => e.IdIgreja == idIgreja)
                .OrderBy(e => e.DataHora)
                .ToListAsync();

            return Ok(eventos);
        }
    }
}