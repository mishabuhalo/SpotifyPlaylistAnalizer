using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class Image
    {
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("url")]
        public string SourceUrl { get; set; }
    }
}
