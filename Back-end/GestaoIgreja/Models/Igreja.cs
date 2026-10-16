using GestaoIgreja.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace GestaoIgreja.Models;

[Table("Igreja")]
public class Igreja
{
    [Key]
    public int IdIgreja { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Denominacao { get; set; }

    [StringLength(255)]
    public string? Endereco { get; set; }

    [StringLength(255)]
    public string? Logotipo { get; set; }

    // Propriedades de Navegação (Relações 1:N)
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    public virtual ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();
}