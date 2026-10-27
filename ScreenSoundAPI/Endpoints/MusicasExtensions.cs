using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Converters;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.DTOs.Requests.Musica;
using ScreenSound.Shared.DTOs.Responses;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        app.MapGet("/musicas", ([FromServices] MusicaDAL dal) =>
        {
            var musicas = dal.Listar().Select(m => new
            {
                m.Id,
                m.Nome,
                NomeArtista = m.Artista!.Nome,
            }).ToList();

            return Results.Ok(musicas);
        });

        app.MapGet("/musicas/{nome}", ([FromServices] MusicaDAL dal, string nome) =>
        {
            var musica = dal.Listar()
            .Where(m => m.Nome.ToUpper().Equals(nome.ToUpper()))
            .Select(m => new MusicaResponse(
                m.Id,
                m.Nome,
                m.AnoLancamento,
                m.ArtistaId,
                m.Artista!.Nome,
                m.Generos.Select(g => g.Id))
            ).FirstOrDefault();

            if (musica is null)
                return Results.NotFound();

            return Results.Ok(musica);
        });

        app.MapPost("/musicas", ([FromServices] MusicaDAL dal, [FromServices] GeneroDAL dalGenero, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(
                musicaRequest.Nome,
                musicaRequest.AnoLancamento,
                musicaRequest.ArtistaId,
                GeneroConverter.GetGenerosById(musicaRequest.Generos, dalGenero) ?? []);

            dal.Adicionar(musica);

            var response = MusicaConverter.EntityToResponse(musica);
            return Results.Created($"/musicas/{response.Id}", response);
        });

        app.MapPut("/musicas/{id}", ([FromServices] MusicaDAL dal, int id, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            if (id != musicaRequestEdit.Id)
                return Results.BadRequest();

            var musicaExistente = dal.RecuperarPor(m => m.Id == id);

            if (musicaExistente is null)
                return Results.NotFound();

            musicaExistente.Nome = musicaRequestEdit.Nome;
            musicaExistente.AnoLancamento = musicaRequestEdit.AnoLancamento;
            musicaExistente.ArtistaId = musicaRequestEdit.ArtistaId;

            dal.Atualizar(musicaExistente);

            var response = MusicaConverter.EntityToResponse(musicaExistente);
            return Results.Ok(response);
        });

        app.MapDelete("/musicas/{id}", ([FromServices] MusicaDAL dal, int id) =>
        {
            var musica = dal.RecuperarPor(m => m.Id == id);

            if (musica is null)
                return Results.NotFound();

            dal.Deletar(musica);
            return Results.NoContent();
        });
    }
}
