using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries
{
    public class GetPlayListInfoByIdQuery: IRequest<PlaylistFull>
    {
        public string PlayListidentifier { get; set; }
    }

    public class GetPlayListInfoByIdQueryHandler : IRequestHandler<GetPlayListInfoByIdQuery, PlaylistFull>
    {
        private ISpotifyService _spotifyService;

        public GetPlayListInfoByIdQueryHandler(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<PlaylistFull> Handle(GetPlayListInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _spotifyService.GetPlaylistInfoById(request.PlayListidentifier);

            return result;
        }
    }
}
