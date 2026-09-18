using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.DTOs.Requests.Artista;

public record ArtistaRequest([Required] string Nome, string Bio, string? FotoPerfil);
