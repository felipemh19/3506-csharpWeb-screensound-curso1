using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class ScreenSoundContext : DbContext
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(m => m.Generos)
            .WithMany(g => g.Musicas)
            .UsingEntity(j => j.ToTable("MusicasGeneros"));
    }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }
}
