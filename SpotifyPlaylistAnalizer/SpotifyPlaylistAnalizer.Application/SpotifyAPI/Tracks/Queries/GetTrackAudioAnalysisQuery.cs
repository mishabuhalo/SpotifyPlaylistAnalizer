using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries
{
    public class GetTrackAudioAnalysisQuery: IRequest<AudioAnalysisFull>
    {
        public string TrackId { get; set; }
    }

    public class GetTrackAudioAnalysisQueryHandler : IRequestHandler<GetTrackAudioAnalysisQuery, AudioAnalysisFull>
    {
        private readonly ISpotifyTracksService _spotifyService;

        public GetTrackAudioAnalysisQueryHandler(ISpotifyTracksService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<AudioAnalysisFull> Handle(GetTrackAudioAnalysisQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyService.GetTrackAudioAnalysis(request.TrackId);
        }
    }
}
