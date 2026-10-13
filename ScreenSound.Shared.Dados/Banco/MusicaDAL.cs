using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class MusicaDAL : DAL<Musica>
{
    public MusicaDAL(ScreenSoundContext context) 
        : base(context) { }

    override public IEnumerable<Musica> Listar()
    {
        return [.. _context.Musicas.Include(m => m.Artista)];
    }
}
