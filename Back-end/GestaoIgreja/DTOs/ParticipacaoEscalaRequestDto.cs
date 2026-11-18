namespace GestaoIgreja.DTOs
{
    public class ParticipacaoEscalaRequestDto
    {
        public int IdUsuario { get; set; }
        public int IdEscala { get; set; }
        public string Status { get; set; } = "Confirmado";
    }
}