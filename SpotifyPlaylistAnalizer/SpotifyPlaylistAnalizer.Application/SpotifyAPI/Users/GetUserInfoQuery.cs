using MediatR;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Application.Models.Users;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.SpotifyAPI.Users
{
    public class GetUserInfoQuery:IRequest<UserViewModel>
    {
        public string UserId { get; set; }
    }

    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserViewModel>
    {
        private readonly ISpotifyUserService _spotifyService;

        public GetUserInfoQueryHandler(ISpotifyUserService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<UserViewModel> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _spotifyService.GetUserInfo(request.UserId);
            //TODO: change on automapper
            return new UserViewModel { Folowers = result.Folowers, Id = result.Id, Images = result.Images, Name = result.Name, Type = result.Type };
        }
    }
}
