using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class AvarageSection
    {
        public float AvarageDuration { get; set; }

        public float AvarageLoudness { get; set; }

        public float AvarageTempo { get; set; }

        public int AvarageKey { get; set; }

        public int AvarageMode { get; set; }

        public int Count { get; set; }
    }
}
