namespace SpotifyPlaylistAnalizer.Application.Models
{
    public class SpotifyTokenSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenEndpoint { get; set; }
        public string GrantType { get; set; }
    }
}
