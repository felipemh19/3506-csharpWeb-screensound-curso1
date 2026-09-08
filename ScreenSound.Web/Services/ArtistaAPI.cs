using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient;

        public ArtistaAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

        public async Task<ArtistaResponse?> GetArtistaByNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
        }

        public async Task CreateArtistaAsync(ArtistaRequest artista)
        {
            await _httpClient.PostAsJsonAsync($"artistas", artista);
        }

        public async Task UpdateAsystaAsync(ArtistaRequestEdit artista)
        {
            await _httpClient.PutAsJsonAsync($"artistas/{artista.Id}", artista);
        }

        public async Task DeleteArtistaAsync(int id)
        {
            await _httpClient.DeleteAsync($"artistas/{id}");
        }
    }
}
