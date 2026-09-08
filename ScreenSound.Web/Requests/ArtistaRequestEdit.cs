using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests;

public record ArtistaRequestEdit(int Id, [Required] string Nome, string Bio) : ArtistaRequest(Nome, Bio);
