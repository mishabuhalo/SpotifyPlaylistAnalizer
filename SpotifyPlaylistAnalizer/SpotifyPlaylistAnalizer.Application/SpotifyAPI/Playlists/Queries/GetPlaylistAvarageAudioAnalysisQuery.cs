using FluentValidation;
using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries
{
    public class GetPlaylistAvarageAudioAnalysisQuery:IRequest<List<AvarageAudioAnalysis>>
    {
        public string PlaylistId { get; set; }
    }

    public class GetPlaylistAvarageAudioAnalysisQueryHandler : IRequestHandler<GetPlaylistAvarageAudioAnalysisQuery, List<AvarageAudioAnalysis>>
    {
        private readonly ISpotifyPlaylistService _spotifyPlaylistService;

        public GetPlaylistAvarageAudioAnalysisQueryHandler(ISpotifyPlaylistService spotifyPlaylistService)
        {
            _spotifyPlaylistService = spotifyPlaylistService;
        }

        public async Task<List<AvarageAudioAnalysis>> Handle(GetPlaylistAvarageAudioAnalysisQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyPlaylistService.GetPlaylistAudioAnalysis(request.PlaylistId);
        }
    }

    public class GetPlaylistAvarageAudioAnalysisQueryValidator : AbstractValidator<GetPlaylistAvarageAudioAnalysisQuery>
    {
        public GetPlaylistAvarageAudioAnalysisQueryValidator()
        {
            RuleFor(query => query.PlaylistId).NotNull().WithMessage("Play list id is required!");
        }
    }

}
