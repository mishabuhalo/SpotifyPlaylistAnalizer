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
    public class GetPlaylistTracksAudioFeaturesQuery: IRequest<List<AudioFeatures>>
    {
        public string PlaylistIdentifier { get; set; }
    }

    public class GetPlaylistTracksAudioFeaturesQueryHandler : IRequestHandler<GetPlaylistTracksAudioFeaturesQuery, List<AudioFeatures>>
    {
        private readonly ISpotifyPlaylistService _spotifyPlaylistService;

        public GetPlaylistTracksAudioFeaturesQueryHandler(ISpotifyPlaylistService spotifyPlaylistService)
        {
            _spotifyPlaylistService = spotifyPlaylistService;
        }

        public async Task<List<AudioFeatures>> Handle(GetPlaylistTracksAudioFeaturesQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyPlaylistService.GetPlayListAudioFeatures(request.PlaylistIdentifier);
        }
    }
}
