namespace GestaoIgreja.DTOs
{
    public class EventoRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataEvento { get; set; }
        public int IdIgreja { get; set; }
    }
}