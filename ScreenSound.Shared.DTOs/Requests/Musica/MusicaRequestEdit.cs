using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.DTOs.Requests.Musica;

public record MusicaRequestEdit(int Id, [Required] string Nome, [Required] int AnoLancamento);