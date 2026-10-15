using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class MusicaDAL : DAL<Musica>
{
    public MusicaDAL(ScreenSoundContext context) 
        : base(context) { }
}
