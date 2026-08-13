using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests.Artista;

public record ArtistaRequestEdit(int Id, [Required] string Nome, string Bio) : ArtistaRequest(Nome, Bio);
