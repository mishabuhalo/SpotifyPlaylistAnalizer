using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyPlaylistService : ISpotifyPlaylistService
    {
        private readonly ISpotifyHttpClientFactory _spotifyHttpClientFactory;
        private readonly ISpotifyTracksService _spotifyTracksService;

        public SpotifyPlaylistService(ISpotifyHttpClientFactory spotifyHttpClientFactory, ISpotifyTracksService spotifyTracksService)
        {

            _spotifyHttpClientFactory = spotifyHttpClientFactory;
            _spotifyTracksService = spotifyTracksService;
        }

        public async Task<List<AudioFeatures>> GetPlayListAudioFeatures(string playlistId)
        {
            var playlist = await GetPlaylistSimplifiedAsync(playlistId);

            List<AudioFeatures> result = new List<AudioFeatures>();

            PagingModel<PlayListTrackSimplified> currentPage = playlist.Tracks;

            while(currentPage.Items!=null)
            {
                foreach(var track in currentPage.Items)
                {
                    result.Add(await _spotifyTracksService.GetTrackAudioFeature(track.Track.Id));
                }

                currentPage = await GetNextPage(currentPage.Next);
            }

            return result;

        }

        private async Task<PagingModel<PlayListTrackSimplified>> GetNextPage(string nextPageUrl)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, nextPageUrl);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsJsonAsync<PagingModel<PlayListTrackSimplified>>();
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

        public async Task<AudioFeatures> GetPlayListAvarageAudioFeature(string playlistId)
        {
            var playlistAudioFeatures = await GetPlayListAudioFeatures(playlistId);

            var result = new AudioFeatures();

            foreach(var playlist in playlistAudioFeatures)
            {
                result.Acousticness += playlist.Acousticness;
                result.Danceability += playlist.Danceability;
                result.DurationInMs += playlist.DurationInMs;
                result.Energy += playlist.Energy;
                result.Instrumentalness += playlist.Instrumentalness;
                result.Key += playlist.Key;
                result.Liveness += playlist.Liveness;
                result.Loudness += playlist.Loudness;
                result.Mode += playlist.Mode;
                result.Speechiness += playlist.Speechiness;
                result.Tempo += playlist.Tempo;
                result.TimeSignature += playlist.TimeSignature;
                result.Valence += playlist.Valence;
            }

            result.Acousticness /= playlistAudioFeatures.Count;
            result.Danceability /= playlistAudioFeatures.Count;
            result.DurationInMs /= playlistAudioFeatures.Count;
            result.Energy /= playlistAudioFeatures.Count;
            result.Instrumentalness /= playlistAudioFeatures.Count;
            result.Key /= playlistAudioFeatures.Count;
            result.Liveness /= playlistAudioFeatures.Count;
            result.Loudness /= playlistAudioFeatures.Count;
            result.Mode /= playlistAudioFeatures.Count;
            result.Speechiness /= playlistAudioFeatures.Count;
            result.Tempo /= playlistAudioFeatures.Count;
            result.TimeSignature /= playlistAudioFeatures.Count;
            result.Valence /= playlistAudioFeatures.Count;


            return result;
        }
    }
}
