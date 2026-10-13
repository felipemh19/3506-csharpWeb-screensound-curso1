using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class ArtistaDAL : DAL<Artista>
{
    public ArtistaDAL(ScreenSoundContext context) 
        : base(context) { }
}
