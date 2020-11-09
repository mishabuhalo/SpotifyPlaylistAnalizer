using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class SpotifyPlaylistsController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyPlaylistsController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylistInfo(string playlistId)
        {
            dynamic test = JsonSerializer.Deserialize<dynamic>(await _spotifyService.GetPlaylistInfoById(playlistId));

            return new JsonResult (test);
        }
    }
}
