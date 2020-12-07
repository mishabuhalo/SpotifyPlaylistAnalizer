using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyPlaylistService
    {
        Task<PlaylistFull> GetPlaylistInfoById(string playListId);
    }
}
