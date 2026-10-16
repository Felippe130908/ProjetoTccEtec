using Microsoft.EntityFrameworkCore;
using GestaoIgreja.Models; // Importa as suas classes

namespace GestaoIgreja.Data;

public class AppDbContext : DbContext
{
    // Construtor obrigatório para a ligação com o MySQL
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // 1. Mapeamento das Tabelas (DbSets)
    public DbSet<Igreja> Igrejas { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Permissao> Permissoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Escala> Escalas { get; set; }
    public DbSet<PresencaEvento> PresencasEventos { get; set; }
    public DbSet<ParticipacaoEscala> ParticipacoesEscalas { get; set; }

    // 2. Configurações Especiais (Ex: Chaves Primárias Compostas)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // O Entity Framework exige que toda tabela tenha uma Chave Primária.
        // Como a tabela PresencaEvento liga Usuário e Evento, a chave é a união dos dois IDs.
        modelBuilder.Entity<PresencaEvento>()
            .HasKey(pe => new { pe.IdUsuario, pe.IdEvento });

        // A mesma regra para a tabela de ParticipacaoEscala
        modelBuilder.Entity<ParticipacaoEscala>()
            .HasKey(pe => new { pe.IdUsuario, pe.IdEscala });
    }
}