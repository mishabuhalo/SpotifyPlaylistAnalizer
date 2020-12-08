using SpotifyPlaylistAnalizer.Application.Models;

namespace SpotifyPlaylistAnalizer.Application.Extensions
{
    public static class TimeIntervalExtension
    {
        public static void AddAvarageTimeInterval(this AvarageTimeInterval targetTimeInterval, TimeInterval newTimeInterval)
        {
            var prevDuration = targetTimeInterval.AvarageDuration * targetTimeInterval.Count;
            targetTimeInterval.Count++;
            targetTimeInterval.AvarageDuration = (prevDuration + newTimeInterval.Duration) / targetTimeInterval.Count;
        }
    }
}
