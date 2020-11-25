using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries
{
    public class GetTrackAudioFeaturesQuery: IRequest<AudioFeatures>
    {
        public string TarckId { get; set; }
    }

    public class GetTrackAudioFeaturesQueryHandler : IRequestHandler<GetTrackAudioFeaturesQuery, AudioFeatures>
    {
        private readonly ISpotifyService _spotifyService;

        public GetTrackAudioFeaturesQueryHandler(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<AudioFeatures> Handle(GetTrackAudioFeaturesQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyService.GetTrackAudioFeature(request.TarckId);
        }
    }
}
