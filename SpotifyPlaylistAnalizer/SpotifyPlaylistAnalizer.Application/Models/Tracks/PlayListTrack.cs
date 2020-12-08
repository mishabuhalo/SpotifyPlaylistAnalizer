using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Tracks
{
    public class PlayListTrack
    {
        [JsonPropertyName("track")]
        public TrackFull Track { get; set; }
        [JsonPropertyName("added_by")]
        public User AddedBy { get; set; }
        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
    }
}
