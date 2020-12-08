using SpotifyPlaylistAnalizer.Application.Models.Artist;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Album
{
    public class AlbumFull
    {
        [JsonPropertyName("album_type")]
        public string Type { get; set; }
        [JsonPropertyName("artists")]
        public List<ArtistSimplified> Artists { get; set; }
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
    }
}
