﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class Segment
    {
        [JsonPropertyName("start")]
        public float Start { get; set; }
        [JsonPropertyName("duration")]
        public float Duration { get; set; }
        [JsonPropertyName("confidence")]
        public float Confidence { get; set; }
        [JsonPropertyName("loudness_start")]
        public float LoudnessStart { get; set; }
        [JsonPropertyName("loudness_max")]
        public float LoudnessMax { get; set; }
        [JsonPropertyName("loudness_max_time")]
        public float LoudnessMaxTime { get; set; }
        [JsonPropertyName("loudness_end")]
        public float LoudnessEnd { get; set; }
        [JsonPropertyName("pitches")]
        public List<float> Pitches { get; set; }
        [JsonPropertyName("timbre")]
        public List<float> Timbre { get; set; }
    }
}
