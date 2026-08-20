using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Converters;
using ScreenSound.API.Requests.Musica;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            var musicas = dal.Listar();

            var response = MusicaConverter.EntityListToResponseList(musicas);
            return Results.Ok(response);
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));

            if (musica is null)
                return Results.NotFound();

            var response = MusicaConverter.EntityToResponse(musica);
            return Results.Ok(response);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Genero> dalGenero, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(
                musicaRequest.Nome, 
                musicaRequest.AnoLancamento, 
                musicaRequest.ArtistaId, 
                GeneroConverter.GeneroRequestConverter(musicaRequest.Generos, dalGenero) ?? []);

            dal.Adicionar(musica);

            var response = MusicaConverter.EntityToResponse(musica);
            return Results.Created($"/Musicas/{response.Id}", response);
        });

        app.MapPut("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            if (id != musicaRequestEdit.Id)
                return Results.BadRequest();

            var musicaExistente = dal.RecuperarPor(m => m.Id == id);

            if (musicaExistente is null)
                return Results.NotFound();

            musicaExistente.Nome = musicaRequestEdit.Nome;
            musicaExistente.AnoLancamento = musicaRequestEdit.AnoLancamento;

            dal.Atualizar(musicaExistente);

            var response = MusicaConverter.EntityToResponse(musicaExistente);
            return Results.Ok(response);
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musica = dal.RecuperarPor(m => m.Id == id);

            if (musica is null)
                return Results.NotFound();

            dal.Deletar(musica);
            return Results.NoContent();
        });
    }
}
