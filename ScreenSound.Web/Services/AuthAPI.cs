using ScreenSound.Shared.DTOs.Responses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class AuthAPI
{
    private readonly HttpClient _httpClient;

    public AuthAPI(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<AuthResponse?> LoginAsync(string email, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login?useCookies=true", new { email, password });

        if (response.IsSuccessStatusCode)
        {
            return new AuthResponse(true, []);
        }
        else
        {
            return new AuthResponse(false, ["Login ou senha inválidos"]);
        }
    }
}
