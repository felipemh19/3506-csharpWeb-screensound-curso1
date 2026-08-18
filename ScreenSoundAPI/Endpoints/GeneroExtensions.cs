using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Converters;
using ScreenSound.API.Requests.Genero;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class GeneroExtensions
{
    public static void AddEndpointGeneros(this WebApplication app)
    {
        app.MapGet("/generos", ([FromServices] DAL<Genero> dal) =>
        {
            var generos = dal.Listar();

            var response = GeneroConverter.EntityListToResponseList(generos);
            return Results.Ok(generos);
        });

        app.MapGet("/generos/{nome}", (int id, [FromServices] DAL<Genero> dal, string nome) =>
        {
            var genero = dal.RecuperarPor(x => x.Nome.ToUpper().Equals(nome.ToUpper()));

            if (genero is null)
                return Results.NotFound();

            var response = GeneroConverter.EntityToResponse(genero);
            return Results.Ok(response);
        });

        app.MapPost("/generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
        {
            var genero = new Genero(generoRequest.Nome, generoRequest.Descricao);

            dal.Adicionar(genero);

            var response = GeneroConverter.EntityToResponse(genero);
            return Results.Created($"/generos/{genero.Id}", response);
        });
    }
}
