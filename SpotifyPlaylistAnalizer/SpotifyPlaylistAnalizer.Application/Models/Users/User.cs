using SpotifyPlaylistAnalizer.Application.Models.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class User
    {
        [JsonPropertyName("display_name")]
        public string Name { get; set; }
        [JsonPropertyName("followers")]
        public Followers Folowers { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
    }
}
