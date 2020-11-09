using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Infrastructure.Services;

namespace SpotifyPlaylistAnalizer.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SpotifyTokenService>(configuration.GetSection("SpotifyTokenSettings"));
            services.AddTransient<ISpotifyTokenService, SpotifyTokenService>();
            return services;
        }
    }
}
