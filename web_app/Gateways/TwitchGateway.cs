using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using web_app.Config;
using web_app.Gateways.Responses;
using web_app.Helpers;
using web_app.ViewModels;

namespace web_app.Gateways
{
    public class TwitchGateway : ITwitchGateway
    {
        private readonly IOptions<UrlConfiguration> _urlConfig;
        private readonly IHttpClientWrapperTwitch _httpClientWrap;

        public TwitchGateway(IOptions<UrlConfiguration> urlCOnfig, IHttpClientWrapperTwitch httpClientWrap)
        {
            _urlConfig = urlCOnfig;
            _httpClientWrap = httpClientWrap;
        }

        public async Task<Response<TwitchTopClipsForGame>> GetTrendingClipsForGame(string game)
        {
            if (string.IsNullOrEmpty(game))
                return new Response<TwitchTopClipsForGame>
                {
                    Status = HttpStatusCode.BadRequest
                };
            
            var url = "https://api.twitch.tv/kraken/clips/top?limit=10&game=Overwatch&trending=true";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await _httpClientWrap.DoRequest<TwitchTopClipsForGame>(request);

            if (result.Status != HttpStatusCode.OK)
            {
                return new Response<TwitchTopClipsForGame>();
            }

            return result;
        }
       
    }
}
