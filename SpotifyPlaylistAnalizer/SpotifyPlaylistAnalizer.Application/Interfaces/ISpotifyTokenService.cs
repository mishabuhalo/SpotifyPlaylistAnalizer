using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyTokenService
    {
        public Task<string> IssueToken();
    }
}
