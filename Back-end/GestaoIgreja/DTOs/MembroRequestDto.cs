namespace GestaoIgreja.DTOs
{
    public class MembroRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = "123456";
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public int IdCargo { get; set; }
        public int IdIgreja { get; set; }
    }
}