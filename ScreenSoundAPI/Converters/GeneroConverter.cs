using ScreenSound.API.Requests.Genero;
using ScreenSound.API.Responses;
using ScreenSound.Shared.Dados.Banco;
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

    internal static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
    {
        var listaGeneros = new List<Genero>();

        foreach (var item in generos)
        {
            var entity = RequestToEntity(item);
            var genero = dalGenero.RecuperarPor(a => a.Nome.ToUpper().Equals(item.Nome.ToUpper()));

            if (genero is not null)
            {
                listaGeneros.Add(genero);
            }
            else
            {
                listaGeneros.Add(entity);
            }
        }

        return listaGeneros;
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero(genero.Nome, genero.Descricao);
    }
}
