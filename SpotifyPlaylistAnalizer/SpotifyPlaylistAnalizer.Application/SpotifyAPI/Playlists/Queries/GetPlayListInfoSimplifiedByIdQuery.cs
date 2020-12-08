using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries
{
    public class GetPlayListInfoSimplifiedQuery: IRequest<PlaylistSimplified>
    {
        public string PlayListidentifier { get; set; }
    }
    public class GetPlayListInfoSimplifiedQueryHandler : IRequestHandler<GetPlayListInfoSimplifiedQuery, PlaylistSimplified>
    {
        private readonly ISpotifyPlaylistService _spotifyPlaylistService;

        public GetPlayListInfoSimplifiedQueryHandler(ISpotifyPlaylistService spotifyPlaylistService)
        {
            _spotifyPlaylistService = spotifyPlaylistService;
        }

        public async Task<PlaylistSimplified> Handle(GetPlayListInfoSimplifiedQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyPlaylistService.GetPlaylistSimplifiedAsync(request.PlayListidentifier);
        }
    }
}
