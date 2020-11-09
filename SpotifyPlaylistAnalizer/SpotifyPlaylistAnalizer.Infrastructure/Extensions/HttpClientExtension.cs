using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            using (var stream = await content.ReadAsStreamAsync())
            {
                T t = await JsonSerializer.DeserializeAsync<T>(stream);
                return t;
            }
        }
    }
}
