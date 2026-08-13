using ScreenSound.API.Responses;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Converters;

internal class ArtistaConverter
{
    internal static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return [.. listaDeArtistas.Select(a => EntityToResponse(a))];
    }

    internal static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio);
    }
}
