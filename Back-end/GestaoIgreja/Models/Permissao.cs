using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Permissao")]
public class Permissao
{
    [Key]
    public int IdPermissao { get; set; }

    [Required]
    [StringLength(50)]
    public string Modulo { get; set; } = string.Empty;

    public bool Visualizar { get; set; } = false;
    public bool Editar { get; set; } = false;
    public bool Excluir { get; set; } = false;

    // Chave Estrangeira
    public int IdCargo { get; set; }
    [ForeignKey("IdCargo")]
    public virtual Cargo Cargo { get; set; } = null!;
}