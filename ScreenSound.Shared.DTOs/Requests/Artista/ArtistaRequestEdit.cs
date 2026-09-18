using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.DTOs.Requests.Artista;

public record ArtistaRequestEdit(int Id, [Required] string Nome, string Bio, string? FotoPerfil) : ArtistaRequest(Nome, Bio, FotoPerfil);
