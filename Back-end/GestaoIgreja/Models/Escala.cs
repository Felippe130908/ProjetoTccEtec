using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Escala")]
public class Escala
{
    [Key]
    public int IdEscala { get; set; }

    [Required]
    [StringLength(100)]
    public string NomeMinisterio { get; set; } = string.Empty; // Ex: Louvor, Coroinhas

    // Chave Estrangeira
    public int IdEvento { get; set; }
    [ForeignKey("IdEvento")]
    public virtual Evento Evento { get; set; } = null!;

    // Navegação
    public virtual ICollection<ParticipacaoEscala> ParticipacoesEscalas { get; set; } = new List<ParticipacaoEscala>();
}