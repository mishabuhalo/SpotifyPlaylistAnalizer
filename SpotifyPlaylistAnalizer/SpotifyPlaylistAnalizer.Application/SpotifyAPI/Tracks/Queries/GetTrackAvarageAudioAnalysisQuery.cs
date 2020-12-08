using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries
{
    public class GetTrackAvarageAudioAnalysisQuery:IRequest<AvarageAudioAnalysis>
    {
        public string TrackId { get; set; }
    }

    public class GetTrackAvarageAudioAnalysisQueryHandler : IRequestHandler<GetTrackAvarageAudioAnalysisQuery, AvarageAudioAnalysis>
    {
        private readonly ISpotifyTracksService _spotifyTracksService;
        public GetTrackAvarageAudioAnalysisQueryHandler(ISpotifyTracksService spotifyTracksService)
        {
            _spotifyTracksService = spotifyTracksService;
        }

        public async Task<AvarageAudioAnalysis> Handle(GetTrackAvarageAudioAnalysisQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyTracksService.GetTrackAvarageAudioAnalysis(request.TrackId);
        }
    }
}
