namespace ScreenSound.Shared.DTOs.Responses;

public record MusicaResponse(int Id, string Nome, int AnoLancamento, int? ArtistaId, string? NomeArtista, IEnumerable<int>? Generos = null);
