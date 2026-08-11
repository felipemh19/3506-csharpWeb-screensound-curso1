using Microsoft.AspNetCore.Mvc;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));

            if (musica is null)
                return Results.NotFound();

            return Results.Ok(musica);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            dal.Adicionar(musica);
            return Results.Created($"/Musicas/{musica.Nome}", musica);
        });

        app.MapPut("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id, [FromBody] Musica musica) =>
        {
            var musicaExistente = dal.RecuperarPor(m => m.Id == id);

            if (musicaExistente is null)
                return Results.NotFound();

            musicaExistente.Nome = musica.Nome;
            musicaExistente.AnoLancamento = musica.AnoLancamento;

            dal.Atualizar(musicaExistente);
            return Results.Ok(musicaExistente);
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
