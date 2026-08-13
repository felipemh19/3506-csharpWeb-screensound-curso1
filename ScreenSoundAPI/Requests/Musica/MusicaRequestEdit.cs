using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests.Musica;

public record MusicaRequestEdit(int Id, [Required] string Nome, [Required] int AnoLancamento);