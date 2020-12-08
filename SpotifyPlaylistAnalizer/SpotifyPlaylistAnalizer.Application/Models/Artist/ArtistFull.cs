using SpotifyPlaylistAnalizer.Application.Models.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Artist
{
    public class ArtistFull
    {
        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Populariry { get; set; }
        [JsonPropertyName("uri")]
        public string Url { get; set; }
    }
}
