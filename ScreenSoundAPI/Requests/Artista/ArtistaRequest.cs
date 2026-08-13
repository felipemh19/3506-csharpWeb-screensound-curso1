using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests.Artista;

public record ArtistaRequest([Required] string Nome, string Bio);
