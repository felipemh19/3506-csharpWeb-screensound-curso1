using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class GeneroDAL : DAL<Genero>
{
    public GeneroDAL(ScreenSoundContext context) 
        : base(context) { }
}
