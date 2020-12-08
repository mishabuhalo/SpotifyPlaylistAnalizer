using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.SpotifyAPI.Tracks.Queries;

namespace SpotifyPlaylistAnalizer.Controllers
{
    [Route("api/tracks")]
    [ApiController]
    public class SpotifyTracksController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetTrackInfo(string trackId)
        {
            var result = await Mediator.Send(new GetTrackByIdQuery() { TrackIdentifier = trackId });
            return Ok(result);
        }

        [HttpGet("audio-features")]
        public async Task<IActionResult> GetTrackAudioFeatures(string trackId)
        {
            var result = await Mediator.Send(new GetTrackAudioFeaturesQuery() { TarckId = trackId });
            return Ok(result);
        }

        [HttpGet("audio-analysis")]
        public async Task<IActionResult> GetTrackAudioAnalysis(string trackId)
        {
            var result = await Mediator.Send(new GetTrackAudioAnalysisQuery() { TrackId = trackId });

            return Ok(result);
        }

        [HttpGet("audio-analysis/avarage")]
        public async Task<IActionResult> GetAvarageTrackAudioAnalysis(string trackId)
        {
            var result = await Mediator.Send(new GetTrackAvarageAudioAnalysisQuery() { TrackId = trackId });

            return Ok(result);
        }
    }
}
