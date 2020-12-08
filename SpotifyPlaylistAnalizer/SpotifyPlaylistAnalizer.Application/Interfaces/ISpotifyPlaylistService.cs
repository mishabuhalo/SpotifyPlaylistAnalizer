using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyPlaylistService
    {
        Task<PlaylistFull> GetPlaylistInfoById(string playListId);
        Task<List<AudioFeatures>> GetPlayListAudioFeatures(string playlistId);
        Task<PlaylistSimplified> GetPlaylistSimplifiedAsync(string playlistId);
    }
}
