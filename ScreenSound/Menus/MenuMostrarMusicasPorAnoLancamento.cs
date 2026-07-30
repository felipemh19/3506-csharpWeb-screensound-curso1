using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAnoLancamento : Menu
{
    private readonly DAL<Musica> _musicaDAL;

    public MenuMostrarMusicasPorAnoLancamento(DAL<Musica> musicaDAL)
    {
        _musicaDAL = musicaDAL;
    }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Exibir músicas por ano de lançamento");
        Console.Write("Digite o ano que deseja visualizar as músicas: ");
        string ano = Console.ReadLine()!;
        var musicasPorAno = _musicaDAL.ListarPor(x => x.AnoLancamento.Equals(Convert.ToInt32(ano)));
        if (musicasPorAno is not null && musicasPorAno.Any())
        {
            Console.WriteLine($"\nMusicas do ano {ano}");
            foreach (var musica in musicasPorAno)
                musica.ExibirFichaTecnica();

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNão foi encontrada nenhuma música para o ano {ano}!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
