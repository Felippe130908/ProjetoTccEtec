using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Evento")]
public class Evento
{
    [Key]
    public int IdEvento { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public DateTime DataHora { get; set; }

    [StringLength(255)]
    public string? Local { get; set; }

    public bool Restrito { get; set; } = false;

    [StringLength(50)]
    public string TipoRepeticao { get; set; } = "Nenhuma";

    // Chave Estrangeira
    public int IdIgreja { get; set; }
    [ForeignKey("IdIgreja")]
    public virtual Igreja Igreja { get; set; } = null!;

    // Navegação
    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();
    public virtual ICollection<PresencaEvento> PresencasEventos { get; set; } = new List<PresencaEvento>();
}