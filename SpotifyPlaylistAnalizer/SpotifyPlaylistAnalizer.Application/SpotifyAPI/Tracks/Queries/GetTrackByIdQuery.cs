using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries
{
    public class GetTrackByIdQuery:IRequest<TrackFull>
    {
        public string TrackIdentifier { get; set; }
    }

    public class GetTeackByIdQueryHandler : IRequestHandler<GetTrackByIdQuery, TrackFull>
    {
        private readonly ISpotifyService _spotifyService;

        public GetTeackByIdQueryHandler(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<TrackFull> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _spotifyService.GetTrackInfoById(request.TrackIdentifier);

            return result;
        }
    }
}
