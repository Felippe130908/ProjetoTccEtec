using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Participacao_Escala")]
public class ParticipacaoEscala
{
    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;

    public int IdEscala { get; set; }
    [ForeignKey("IdEscala")]
    public virtual Escala Escala { get; set; } = null!;

    [StringLength(50)]
    public string Status { get; set; } = "Confirmado";
}