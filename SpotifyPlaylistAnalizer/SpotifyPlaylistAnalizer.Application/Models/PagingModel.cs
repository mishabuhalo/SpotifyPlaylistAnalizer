using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class PagingModel<T>
    {
        [JsonPropertyName("href")]
        public string Url { get; set; }
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; }
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
