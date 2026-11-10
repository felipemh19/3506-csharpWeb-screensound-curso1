using ScreenSound.API.Endpoints;
using ScreenSound.Shared.Dados.Banco;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddScoped<MusicaDAL>();
builder.Services.AddScoped<ArtistaDAL>();
builder.Services.AddScoped<GeneroDAL>();

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7191",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7019"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

app.UseRouting();
app.UseCors("wasm");

app.UseStaticFiles();

app.AddEndpointsArtistas();
app.AddEndpointsMusicas();
app.AddEndpointGeneros();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
