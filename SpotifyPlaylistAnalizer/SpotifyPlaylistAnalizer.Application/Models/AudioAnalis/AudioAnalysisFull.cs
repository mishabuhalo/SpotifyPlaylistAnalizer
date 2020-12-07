using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SpotifyPlaylistAnalizer.Application.Models.AudioAnalis
{
    public class AudioAnalysisFull
    {
        [JsonPropertyName("bars")]
        public List<TimeInterval> Bars { get; set; }
        [JsonPropertyName("beats")]
        public List<TimeInterval> Beats { get; set; }
        [JsonPropertyName("sections")]
        public List<Section> Sections { get; set; }
        [JsonPropertyName("segments")]
        public List<Segment> Segments { get; set; }
        [JsonPropertyName("tatums")]
        public List<TimeInterval> Tatums { get; set; }
    }
}
