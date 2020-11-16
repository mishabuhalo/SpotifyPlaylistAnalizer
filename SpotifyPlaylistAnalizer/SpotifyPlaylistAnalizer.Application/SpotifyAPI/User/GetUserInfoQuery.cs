using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.User
{
    public class GetUserInfoQuery:IRequest<string>
    {
        public string UserId { get; set; }
    }

    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, string>
    {
        private readonly ISpotifyService _spotifyService;

        public GetUserInfoQueryHandler(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<string> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            return await _spotifyService.GetUserInfo(request.UserId);
        }
    }
}
