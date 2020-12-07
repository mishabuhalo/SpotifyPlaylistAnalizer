using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Infrastructure.Services;

namespace SpotifyPlaylistAnalizer.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SpotifyTokenSettings>(configuration.GetSection("SpotifyTokenSettings"));
            services.AddTransient<ISpotifyTokenService, SpotifyTokenService>();
            services.AddHttpClient<ISpotifyHttpClientFactory, SpotifyHttpClientFactory>();
            services.AddTransient<ISpotifyTracksService, SpotifyTrackService>();
            services.AddTransient<ISpotifyUserService, SpotifyUserService>();
            services.AddTransient<ISpotifyPlaylistService, SpotifyPlaylistService>();
            return services;
        }
    }
}
