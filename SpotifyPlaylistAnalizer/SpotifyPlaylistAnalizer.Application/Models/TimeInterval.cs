using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class TimeInterval
    {
        [JsonPropertyName("start")]
        public float Start { get; set; }
        [JsonPropertyName("duration")]
        public float Duration { get; set; }
        [JsonPropertyName("confidence")]
        public float Confidence { get; set; }
    }
}
