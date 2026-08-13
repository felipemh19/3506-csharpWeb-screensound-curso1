using ScreenSound.API.Responses;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Converters;

internal class MusicaConverter
{
    internal static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> listaDeMusicas)
    {
        return [.. listaDeMusicas.Select(m => EntityToResponse(m))];
    }

    internal static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome, musica.AnoLancamento, musica.ArtistaId);
    }
}
