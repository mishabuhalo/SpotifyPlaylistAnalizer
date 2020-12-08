using SpotifyPlaylistAnalizer.Application.Models.Album;
using SpotifyPlaylistAnalizer.Application.Models.Artist;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Tracks
{
    public class TrackFull
    {
        [JsonPropertyName("album")]
        public AlbumSimplified Album { get; set; }
        [JsonPropertyName("artists")]
        public List<ArtistSimplified> Artists { get; set; }
        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }
        [JsonPropertyName("duration_ms")]
        public int Duration { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }
}
