namespace ScreenSound.Shared.Modelos.Modelos;

public class Musica : Base
{
    public Musica(string nome)
    {
        Nome = nome;
    }

    public Musica(string nome, int? anoLancamento, int? artistaId, ICollection<Genero> generos)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
        ArtistaId = artistaId;
        Generos = generos;
    }

    public string Nome { get; set; }
    public int? AnoLancamento { get; set; }
    public int? ArtistaId { get; set; }
    public virtual Artista? Artista { get; set; }
    public virtual ICollection<Genero> Generos { get; set; } = [];

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome} - Artista: {Artista?.Nome} - Ano: {AnoLancamento}");      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}
        Ano de lançamento: {AnoLancamento}
        Artista: {Artista?.Nome}";
        
    }
}