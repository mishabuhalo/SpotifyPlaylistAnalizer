using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Artist
{
    public class ArtistSimplified
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("uri")]
        public string Url { get; set; }
    }
}
