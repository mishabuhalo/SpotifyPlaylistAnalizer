using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.AudioAnalis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries
{
    public class GetPlaylistAvarageAudioFeatureQuery:IRequest<AudioFeatures>
    {
        public string PlaylistIdentifier { get; set; }
    }

    public class GetPlaylistAvarageAudioFeatureQueryHandler : IRequestHandler<GetPlaylistAvarageAudioFeatureQuery, AudioFeatures>
    {
        private readonly ISpotifyPlaylistService _spotifyPlaylistService;

        public GetPlaylistAvarageAudioFeatureQueryHandler(ISpotifyPlaylistService spotifyPlaylistService)
        {
            _spotifyPlaylistService = spotifyPlaylistService;
        }

        public async Task<AudioFeatures> Handle(GetPlaylistAvarageAudioFeatureQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyPlaylistService.GetPlayListAvarageAudioFeature(request.PlaylistIdentifier);
        }
    }
}
