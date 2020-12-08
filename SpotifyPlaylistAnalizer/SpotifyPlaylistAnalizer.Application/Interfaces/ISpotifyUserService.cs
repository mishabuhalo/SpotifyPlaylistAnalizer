using SpotifyPlaylistAnalizer.Application.Models;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyUserService
    {
        Task<User> GetUserInfo(string userId);
    }
}
