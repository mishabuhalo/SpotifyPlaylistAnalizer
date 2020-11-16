using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using SpotifyPlaylistAnalizer.Application.Models.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.Playlist
{
    public class PlaylistFull
    {
        [JsonPropertyName("collaborative")]
        public bool CanModify { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("owner")]
        public User User { get; set; }
        [JsonPropertyName("tracks")]
        public PagingModel<PlayListTrack> Tracks { get; set; }
        [JsonPropertyName("uri")]
        public string Url { get; set; }

    }
}
