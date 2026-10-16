using GestaoIgreja.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Cargo")]
public class Cargo
{
    [Key]
    public int IdCargo { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    // Chave Estrangeira
    public int IdIgreja { get; set; }
    [ForeignKey("IdIgreja")]
    public virtual Igreja Igreja { get; set; } = null!;

    // Navegação
    public virtual ICollection<Permissao> Permissoes { get; set; } = new List<Permissao>();
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}