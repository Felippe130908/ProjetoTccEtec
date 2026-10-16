using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Presenca_Evento")]
public class PresencaEvento
{
    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;

    public int IdEvento { get; set; }
    [ForeignKey("IdEvento")]
    public virtual Evento Evento { get; set; } = null!;

    public DateTime DataConfirmacao { get; set; } = DateTime.Now;
}