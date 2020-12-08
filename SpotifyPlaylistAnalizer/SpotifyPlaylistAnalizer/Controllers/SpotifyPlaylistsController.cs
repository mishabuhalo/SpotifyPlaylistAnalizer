using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class SpotifyPlaylistsController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetPlaylistInfo(string playlistId)
        {
            var result = await Mediator.Send(new GetPlayListInfoByIdQuery() { PlayListidentifier = playlistId});

            return Ok(result);
        }

        [HttpGet]
        [Route("simplified")]
        public async Task<IActionResult> GetPlaylistInfoSimplified(string playlistId)
        {
            var result = await Mediator.Send(new GetPlayListInfoSimplifiedQuery() { PlayListidentifier = playlistId });

            return Ok(result);
        }
    }
}
