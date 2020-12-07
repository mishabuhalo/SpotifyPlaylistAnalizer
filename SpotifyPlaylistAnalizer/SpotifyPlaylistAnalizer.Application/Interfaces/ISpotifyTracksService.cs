using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyTracksService
    {
        Task<TrackFull> GetTrackInfoById(string trackId);
        Task<AudioFeatures> GetTrackAudioFeature(string trackId);
        Task<AudioAnalysisFull> GetTrackAudioAnalysis(string trackId);
    }
}
