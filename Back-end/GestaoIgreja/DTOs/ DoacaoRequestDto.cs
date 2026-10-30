namespace GestaoIgreja.DTOs

{

    public class DoacaoRequestDto

    {

        public decimal Valor { get; set; }

        public string Categoria { get; set; } = string.Empty; // Ex: Dízimo, Oferta

        public string? ComprovanteUrl { get; set; }

        public int IdUsuario { get; set; } // Quem doou

        public int IdIgreja { get; set; }  // Para qual igreja

    }

}
