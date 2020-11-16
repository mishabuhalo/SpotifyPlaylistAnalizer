using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyService
    {
        Task<string> GetPlaylistInfoById(string playListId);
        Task<string> GetTrackInfoById(string trackId);
        Task<string> GetUserInfo(string userId);
    }
}
