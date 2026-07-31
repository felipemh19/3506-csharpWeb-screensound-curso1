using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{
    private readonly DAL<Artista> _artistaDAL;

    public MenuRegistrarArtista(DAL<Artista> artistaDAL)
    {
        _artistaDAL = artistaDAL;
    }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        Artista artista = new Artista(nomeDoArtista, bioDoArtista);
        _artistaDAL.Adicionar(artista);
        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
