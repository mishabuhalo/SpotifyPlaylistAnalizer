using SpotifyPlaylistAnalizer.Application.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyHttpClientFactory : ISpotifyHttpClientFactory
    {
        private readonly HttpClient _httpClient;
        private readonly ISpotifyTokenService _spotifyTokenService;

        public SpotifyHttpClientFactory(HttpClient httpClient, ISpotifyTokenService spotifyTokenService)
        {
            httpClient.BaseAddress = new System.Uri("https://api.spotify.com/v1/");
            _httpClient = httpClient;
            _spotifyTokenService = spotifyTokenService;
        }

        public async Task<HttpClient> CreateHttpClient()
        {
            var token = await _spotifyTokenService.IssueToken();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return _httpClient;
        }
    }
}
