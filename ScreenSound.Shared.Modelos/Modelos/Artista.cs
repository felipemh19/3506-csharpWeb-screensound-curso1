namespace ScreenSound.Shared.Modelos.Modelos;

public class Artista : Base
{
    public string Nome { get; set; } = string.Empty;
    public string FotoPerfil { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public virtual ICollection<Musica> Musicas { get; set; } = [];

    public Artista() { }

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}