using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using web_app.Config;

namespace web_app.Helpers
{
    public class HttpClientWrapperTwitch : IHttpClientWrapperTwitch
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientWrapper> _logger;
        private readonly IOptions<TwitchApiConfiguration> _twitch;

        public HttpClientWrapperTwitch(IOptions<TwitchApiConfiguration> twitch)
        {
            _twitch = twitch;
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.twitchtv.v5+json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Client-ID", $"{ _twitch.Value.ClientId}");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", $"application/vnd.twitchtv.v5+json");
        }

        public void ChangeAuthenticationHeader(string authHeader)
        {
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }

        public async Task<Response<T>> DoRequest<T>(string url) where T : class, new()
        {
            return await DoRequest<T>(new HttpRequestMessage(HttpMethod.Get, url));
        }

        public async Task<Response<T>> DoRequest<T>(HttpRequestMessage message) where T : class, new()
        {
            try
            {
                var response = await _httpClient.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();
                return Response<T>.Get(message.RequestUri.ToString(), content, response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(999), ex, "Unknown issue getting and deserializing an HTTP response!");
                return Response<T>.Get(message.RequestUri.ToString(), "{}", HttpStatusCode.BadRequest);
            }
        }
        
    }
}