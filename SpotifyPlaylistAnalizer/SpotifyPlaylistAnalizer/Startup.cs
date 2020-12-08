using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotifyPlaylistAnalizer.Application.SpotifyAPI.Playlists.Queries;
using SpotifyPlaylistAnalizer.Application.SpotifyAPI.Users;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using SpotifyPlaylistAnalizer.Middleware;

namespace SpotifyPlaylistAnalizer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation((fv)=>
            {
                fv.RegisterValidatorsFromAssemblyContaining<GetPlaylistAvarageAudioAnalysisQueryValidator>();
            });
            services.AddMediatR(typeof(GetUserInfoQuery).Assembly);
            services.AddSwaggerGen();
            services.AddInfrastructure(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(conf => {
                conf.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify playlist analizer");
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
