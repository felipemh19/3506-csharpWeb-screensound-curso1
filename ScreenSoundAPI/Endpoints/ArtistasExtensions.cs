using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Converters;
using ScreenSound.API.Requests.Artista;
using ScreenSound.API.Responses;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            var artistas = dal.Listar();

            var response = ArtistaConverter.EntityListToResponseList(artistas);
            return Results.Ok(response);
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (artista is null)
                return Results.NotFound();

            var response = ArtistaConverter.EntityToResponse(artista);
            return Results.Ok(response);
        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);

            dal.Adicionar(artista);

            var response = ArtistaConverter.EntityToResponse(artista);
            return Results.Created($"/Artistas/{response.Id}", response);
        });

        app.MapPut("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            if (id != artistaRequestEdit.Id)
                return Results.BadRequest();

            var artistaExistente = dal.RecuperarPor(a => a.Id == id);
            if (artistaExistente is null)
                return Results.NotFound();

            artistaExistente.Nome = artistaRequestEdit.Nome;
            artistaExistente.Bio = artistaRequestEdit.Bio;

            dal.Atualizar(artistaExistente);

            var response = ArtistaConverter.EntityToResponse(artistaExistente);
            return Results.Ok(response);
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artista = dal.RecuperarPor(a => a.Id == id);
            if (artista is null)
                return Results.NotFound();

            dal.Deletar(artista);
            return Results.NoContent();
        });
    }
}
