using ScreenSound.Shared.DTOs.Requests.Genero;
using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.DTOs.Requests.Musica;

public record MusicaRequest([Required] string Nome, [Required] int AnoLancamento, [Required] int ArtistaId, ICollection<GeneroRequest> Generos = null);
