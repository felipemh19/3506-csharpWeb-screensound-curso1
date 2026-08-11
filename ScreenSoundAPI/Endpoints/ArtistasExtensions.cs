using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (artista is null)
                return Results.NotFound();

            return Results.Ok(artista);
        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);

            dal.Adicionar(artista);
            return Results.Created($"/Artistas/{artista.Nome}", artista);
        });

        app.MapPut("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id, [FromBody] Artista artista) =>
        {
            var artistaExistente = dal.RecuperarPor(a => a.Id == id);
            if (artistaExistente is null)
                return Results.NotFound();

            artistaExistente.Nome = artista.Nome;
            artistaExistente.Bio = artista.Bio;
            artistaExistente.FotoPerfil = artista.FotoPerfil;

            dal.Atualizar(artistaExistente);
            return Results.Ok(artistaExistente);
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
