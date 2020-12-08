using Microsoft.Extensions.Options;
using SpotifyPlaylistAnalizer.Application.Interfaces;
using SpotifyPlaylistAnalizer.Application.Models;
using SpotifyPlaylistAnalizer.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpotifyPlaylistAnalizer.Infrastructure.Services
{

    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
    public class SpotifyTokenService: ISpotifyTokenService
    {
        private readonly SpotifyTokenSettings _spotifyTokenSettings;
        private TokenResponse _tokenResponse;
        public SpotifyTokenService(IOptionsMonitor<SpotifyTokenSettings> spotifyTokenSettings)
        {
            _spotifyTokenSettings = spotifyTokenSettings.CurrentValue;
        }

        public async Task<string> IssueToken()
        {
            //TO DO check if expired
            //if(IsExpired())
            //{
                await RenewToken();
            //}

            return _tokenResponse.AccessToken;
        }

        private bool IsExpired()
        {
            throw new NotImplementedException();
        }

        private async Task RenewToken()
        {
            var requestUrl = _spotifyTokenSettings.TokenEndpoint;

            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl) { Content= GenerateRequestContent()};

            var authHeader = $"{_spotifyTokenSettings.ClientId}:{_spotifyTokenSettings.ClientSecret}";

            httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(authHeader)));

            var response = await httpClient.SendAsync(httpRequestMessage);

            if(response.IsSuccessStatusCode)
            {
                _tokenResponse = await response.Content.ReadAsJsonAsync<TokenResponse>();
            }

        }

        private FormUrlEncodedContent GenerateRequestContent()
        {
            var pairs = new[]
            {
                new KeyValuePair<string, string>("grant_type", _spotifyTokenSettings.GrantType)
            };
            return new FormUrlEncodedContent(pairs);
        }
    }
}
