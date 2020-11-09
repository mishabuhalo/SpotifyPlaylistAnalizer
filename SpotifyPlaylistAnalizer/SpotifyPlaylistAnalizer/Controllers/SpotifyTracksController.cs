﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistAnalizer.Application.Interfaces;

namespace SpotifyPlaylistAnalizer.Controllers
{
    [Route("api/tracks")]
    [ApiController]
    public class SpotifyTracksController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyTracksController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrackInfo(string trackId)
        {
            dynamic test = JsonSerializer.Deserialize<dynamic>(await _spotifyService.GetTrackInfoById(trackId));
            return Ok(test);
        }
    }
}
