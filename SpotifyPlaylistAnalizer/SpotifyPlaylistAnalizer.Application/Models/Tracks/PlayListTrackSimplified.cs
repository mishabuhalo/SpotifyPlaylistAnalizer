using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Tracks
{
    public class PlayListTrackSimplified
    {
        [JsonPropertyName("track")]
        public TrackSimplified Track { get; set; }
    }
}
