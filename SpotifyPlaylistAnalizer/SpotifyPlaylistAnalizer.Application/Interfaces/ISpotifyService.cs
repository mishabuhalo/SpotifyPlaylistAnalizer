﻿using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Application.Models.Playlist;
using SpotifyPlaylistAnalizer.Application.Models.Tracks;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Application.Interfaces
{
    public interface ISpotifyService
    {
        Task<PlaylistFull> GetPlaylistInfoById(string playListId);
        Task<TrackFull> GetTrackInfoById(string trackId);
        Task<User> GetUserInfo(string userId);
    }
}
