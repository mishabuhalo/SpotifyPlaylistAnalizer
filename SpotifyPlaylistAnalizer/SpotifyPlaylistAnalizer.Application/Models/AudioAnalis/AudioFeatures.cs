using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.AudioAnalis
{
    public class AudioFeatures
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("duration_ms")]
        public int DurationInMs { get; set; }
        [JsonPropertyName("key")]
        public int Key { get; set; }
        [JsonPropertyName("mode")]
        public int Mode { get; set; }
        [JsonPropertyName("time_signature")]
        public int TimeSignature { get; set; }
        [JsonPropertyName("acousticness")]
        public float Acousticness { get; set; }
        [JsonPropertyName("danceability")]
        public float Danceability { get; set; }
        [JsonPropertyName("energy")]
        public float Energy { get; set; }
        [JsonPropertyName("instrumentalness")]
        public float Instrumentalness { get; set; }
        [JsonPropertyName("liveness")]
        public float Liveness { get; set; }
        [JsonPropertyName("loudness")]
        public float Loudness { get; set; }
        [JsonPropertyName("speechiness")]
        public float Speechiness { get; set; }
        [JsonPropertyName("valence")]
        public float Valence { get; set; }
        [JsonPropertyName("tempo")]
        public float Tempo { get; set; }
    }
}
