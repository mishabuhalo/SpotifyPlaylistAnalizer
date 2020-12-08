using SpotifyPlaylistAnalizer.Application.Extensions;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{
    public class SpotifyTrackService: ISpotifyTracksService
    {
        private const float Precision = 0.4f;
        private readonly ISpotifyHttpClientFactory _spotifyHttpClientFactory;

        public SpotifyTrackService(ISpotifyHttpClientFactory spotifyHttpClientFactory)
        {
            _spotifyHttpClientFactory = spotifyHttpClientFactory;
        }

        public async Task<TrackFull> GetTrackInfoById(string trackId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"tracks/{trackId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsJsonAsync<TrackFull>();
        }

        public async Task<AudioFeatures> GetTrackAudioFeature(string trackId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"audio-features/{trackId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsJsonAsync<AudioFeatures>();
        }

        public async Task<AudioAnalysisFull> GetTrackAudioAnalysis(string trackId)
        {
            HttpClient httpClient = await _spotifyHttpClientFactory.CreateHttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"audio-analysis/{trackId}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsJsonAsync<AudioAnalysisFull>();
        }

        public async Task<AvarageAudioAnalysis> GetTrackAvarageAudioAnalysis(string trackId)
        {
            var fullAudioAnalis = await GetTrackAudioAnalysis(trackId);

            var result = new AvarageAudioAnalysis();
            result.AvarageBars = new AvarageTimeInterval();
            result.AvarageBeats = new AvarageTimeInterval();
            result.AvarageTatums = new AvarageTimeInterval();

            foreach(var bar in fullAudioAnalis.Bars)
            {
                if (bar.Confidence >= Precision)
                    result.AvarageBars.AddAvarageTimeInterval(bar);
            }

            foreach(var beat in fullAudioAnalis.Beats)
            {
                if (beat.Confidence >= Precision)
                    result.AvarageBeats.AddAvarageTimeInterval(beat);
            }

            foreach(var tatum in fullAudioAnalis.Tatums)
            {
                if(tatum.Confidence>=Precision)
                {
                    result.AvarageTatums.AddAvarageTimeInterval(tatum);
                }
            }
            result.AvarageSection = CalculateAvarageSection(fullAudioAnalis.Sections);

            return result;
        }


        public AvarageSection CalculateAvarageSection(List<Section> sections)
        {
            float fullDuration = 0f;
            float fullLoudness = 0f;
            float fullTempo = 0f;
            float fullKey = 0;
            float fullMode = 0;
            int counter = 0;

            foreach(var section in sections)
            {
                if (section.Confidence < Precision)
                    continue;
                fullDuration += section.Duration;
                fullLoudness += section.Loudness;
                if(section.TempoConfidence>=Precision)
                {
                    fullTempo += section.Tempo;
                }
                if (section.KeyConfidence >= Precision)
                {
                    fullKey += section.Key;
                }
                if (section.ModeConfidence >= Precision)
                {
                    fullMode += section.Mode;
                }

                counter++;

            }

            int reliableTempoCount = sections.Where(x => x.TempoConfidence >= Precision).Count();
            int reliableKeyCount = sections.Where(x => x.KeyConfidence >= Precision).Count();
            int reliableModeCount = sections.Where(x => x.ModeConfidence >= Precision).Count();


            return new AvarageSection
            {
                AvarageDuration = fullDuration / sections.Count,
                AvarageLoudness = fullLoudness / sections.Count,
                AvarageTempo = fullTempo / reliableTempoCount,
                AvarageKey = (int)fullKey / reliableKeyCount,
                AvarageMode = (int)fullKey / reliableModeCount,
                Count = counter
            };
        }
    }
}
