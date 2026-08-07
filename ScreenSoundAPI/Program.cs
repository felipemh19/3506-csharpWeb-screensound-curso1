using Microsoft.AspNetCore.Mvc;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => 
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

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

app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
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

app.Run();
