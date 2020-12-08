using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyPlaylistService : ISpotifyPlaylistService
    {
        private readonly ISpotifyHttpClientFactory _spotifyHttpClientFactory;

        public SpotifyPlaylistService(ISpotifyHttpClientFactory spotifyHttpClientFactory) { 
        
            _spotifyHttpClientFactory = spotifyHttpClientFactory;
        }

        public Task<List<AudioFeatures>> GetPlayListAudioFeatures(string playlistId)
        {
            return null;
        }

        public async Task<PlaylistSimplified> GetPlaylistSimplifiedAsync(string playlistId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"playlists/{playlistId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            var test = await response.Content.ReadAsStringAsync();

            return await response.Content.ReadAsJsonAsync<PlaylistSimplified>();
        }

        public async Task<PlaylistFull> GetPlaylistInfoById(string playListId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"playlists/{playListId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            var test = await response.Content.ReadAsStringAsync();

            return await response.Content.ReadAsJsonAsync<PlaylistFull>();
        }
    }
}
