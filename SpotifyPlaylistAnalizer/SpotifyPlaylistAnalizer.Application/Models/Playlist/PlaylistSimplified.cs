using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Playlist
{
    public class PlaylistSimplified
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("tracks")]
        public PagingModel<PlayListTrackSimplified> Tracks { get; set; }
    }
}
