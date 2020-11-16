using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Users
{
    public class Followers
    {
        [JsonPropertyName("href")]
        public string ApiUrl { get; set; }

        [JsonPropertyName("total")]
        public int TotalCount { get; set; }
    }
}
