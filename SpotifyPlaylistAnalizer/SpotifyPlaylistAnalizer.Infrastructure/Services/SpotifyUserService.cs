using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyUserService: ISpotifyUserService
    {
        private readonly ISpotifyHttpClientFactory _spotifyHttpClientFactory;

        public SpotifyUserService(ISpotifyHttpClientFactory spotifyHttpClientFactory)
        {
            _spotifyHttpClientFactory = spotifyHttpClientFactory;
        }

        public async Task<User> GetUserInfo(string userId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"users/{userId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsJsonAsync<User>();
        }
    }
}
