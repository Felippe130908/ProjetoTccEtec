using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIgreja.Models;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string SenhaHash { get; set; } = string.Empty;

    [StringLength(14)]
    public string? Cpf { get; set; }

    public DateTime? DataNascimento { get; set; }

    [StringLength(20)]
    public string? Telefone { get; set; }

    [StringLength(255)]
    public string? Foto { get; set; }

    public bool Ativo { get; set; } = true;

    // Chaves Estrangeiras
    public int IdIgreja { get; set; }
    [ForeignKey("IdIgreja")]
    public virtual Igreja Igreja { get; set; } = null!;

    public int IdCargo { get; set; }
    [ForeignKey("IdCargo")]
    public virtual Cargo Cargo { get; set; } = null!;

    // Navegação (Muitos-para-Muitos e 1:N)
    public virtual ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();
    public virtual ICollection<PresencaEvento> PresencasEventos { get; set; } = new List<PresencaEvento>();
    public virtual ICollection<ParticipacaoEscala> ParticipacoesEscalas { get; set; } = new List<ParticipacaoEscala>();
}