using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    private readonly DAL<Artista> _artistaDAL;

    public MenuMostrarArtistas(DAL<Artista> artistaDAL)
    {
        _artistaDAL = artistaDAL;
    }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in _artistaDAL.Listar())
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
