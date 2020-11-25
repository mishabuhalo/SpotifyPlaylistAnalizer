using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries
{
    public class GetTrackAudioAnalysisQuery: IRequest<AudioAnalysis>
    {
        public string TrackId { get; set; }
    }

    public class GetTrackAudioAnalysisQueryHandler : IRequestHandler<GetTrackAudioAnalysisQuery, AudioAnalysis>
    {
        private readonly ISpotifyService _spotifyService;

        public GetTrackAudioAnalysisQueryHandler(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<AudioAnalysis> Handle(GetTrackAudioAnalysisQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyService.GetTrackAudioAnalysis(request.TrackId);
        }
    }
}
