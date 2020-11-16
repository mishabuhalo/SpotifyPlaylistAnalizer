using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistAnalizer.Application.SpotifyAPI.User;

namespace SpotifyPlaylistAnalizer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserInfo(string userId)
        {
            dynamic result = JsonSerializer.Deserialize<dynamic>(await Mediator.Send(new GetUserInfoQuery() { UserId = userId}));

            return Ok(result);
        }
    }
}
