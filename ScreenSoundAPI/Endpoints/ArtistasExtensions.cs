using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Converters;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.DTOs.Requests.Artista;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
        app.MapGet("/artistas", ([FromServices] DAL<Artista> dal) =>
        {
            var artistas = dal.Listar();

            var response = ArtistaConverter.EntityListToResponseList(artistas);
            return Results.Ok(response);
        });

        app.MapGet("/artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (artista is null)
                return Results.NotFound();

            var response = ArtistaConverter.EntityToResponse(artista);
            return Results.Ok(response);
        });

        app.MapPost("/artistas", async ([FromServices] DAL<Artista> dal, [FromServices] IHostEnvironment env, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var nome = artistaRequest.Nome.Trim();
            var imagemArtista = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

            var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemArtista);

            using var ms = new MemoryStream(Convert.FromBase64String(artistaRequest.FotoPerfil!));
            using var fs = new FileStream(path, FileMode.Create);

            await ms.CopyToAsync(fs);

            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio)
            {
                FotoPerfil = $"/FotosPerfil/{imagemArtista}"
            };

            dal.Adicionar(artista);

            var response = ArtistaConverter.EntityToResponse(artista);
            return Results.Created($"/Artistas/{response.Id}", response);
        });

        app.MapPut("/artistas/{id}", ([FromServices] DAL<Artista> dal, int id, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
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

        app.MapDelete("/artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artista = dal.RecuperarPor(a => a.Id == id);
            if (artista is null)
                return Results.NotFound();

            dal.Deletar(artista);
            return Results.NoContent();
        });
    }
}
