using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyHttpClientFactory
    {
        Task<HttpClient> CreateHttpClient();
    }
}
