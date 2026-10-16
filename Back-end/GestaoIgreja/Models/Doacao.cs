using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Doacao")]
public class Doacao
{
    [Key]
    public int IdDoacao { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    [Required]
    [StringLength(50)]
    public string Categoria { get; set; } = string.Empty; // Dízimo, Oferta, etc

    [StringLength(255)]
    public string? ComprovanteUrl { get; set; }

    [StringLength(255)]
    public string? QrCodeGerado { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = "Pendente";

    // Chaves Estrangeiras
    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;

    public int IdIgreja { get; set; }
    [ForeignKey("IdIgreja")]
    public virtual Igreja Igreja { get; set; } = null!;
}