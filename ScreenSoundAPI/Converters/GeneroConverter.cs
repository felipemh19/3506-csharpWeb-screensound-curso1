using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.DTOs.Requests.Genero;
using ScreenSound.Shared.DTOs.Responses;
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

    internal static ICollection<Genero> GetGenerosById(ICollection<int> generos, DAL<Genero> dalGenero)
    {
        var listaGeneros = new List<Genero>();

        if (generos is not null)
        {
            foreach (var item in generos)
            {
                var genero = dalGenero.RecuperarPor(a => a.Id == item);

                if (genero is not null)
                {
                    listaGeneros.Add(genero);
                }
            } 
        }

        return listaGeneros;
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero(genero.Nome, genero.Descricao);
    }
}
