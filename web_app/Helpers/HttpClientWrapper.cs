using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using web_app.Config;

namespace web_app.Helpers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<TraktApiConfiguration> _traktConfig;

        public HttpClientWrapper(IOptions<TraktApiConfiguration> traktConfig)
        {
            _traktConfig = traktConfig;
            var token = "";
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-key", $"{ _traktConfig.Value.ApiKey}");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-version", "2");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", $"Bearer { _traktConfig.Value.AuthorizationBearer}");
        }
        public Task<Response<T>> DoRequest<T>(string url) where T : class, new()
        {
            throw new NotImplementedException();
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
                return Response<T>.Get(message.RequestUri.ToString(), "{}", HttpStatusCode.BadRequest);
            }
        }
    }
}
