using ScreenSound.API.Requests.Genero;
using ScreenSound.API.Responses;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Converters;

public class GeneroConverter
{
    internal static ICollection<GeneroResponse> EntityListToResponseList(IEnumerable<Genero> listaDeGeneros)
    {
        return [.. listaDeGeneros.Select(a => EntityToResponse(a))];
    }

    internal static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Id, genero.Nome, genero.Descricao);
    }

    internal static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos)
    {
        return [.. generos.Select(a => RequestToEntity(a))];
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero(genero.Nome, genero.Descricao);
    }
}
