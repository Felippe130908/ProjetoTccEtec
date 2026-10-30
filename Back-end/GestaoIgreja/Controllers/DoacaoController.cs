using Microsoft.AspNetCore.Mvc;

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

    }

}
