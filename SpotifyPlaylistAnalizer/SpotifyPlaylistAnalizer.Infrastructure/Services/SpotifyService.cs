using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyService: ISpotifyService
    {
        private readonly ISpotifyHttpClientFactory _spotifyHttpClientFactory;

        public SpotifyService(ISpotifyHttpClientFactory spotifyHttpClientFactory)
        {
            _spotifyHttpClientFactory = spotifyHttpClientFactory;
        }

        public async Task<string> GetPlaylistInfoById(string playListId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"playlists/{playListId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTrackInfoById(string trackId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"tracks/{trackId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsStringAsync();
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
