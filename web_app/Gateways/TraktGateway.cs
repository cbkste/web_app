using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using web_app.Helpers;

namespace web_app.Gateways
{
    public class TraktGateway : ITraktGateway
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public TraktGateway(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<object> getLastWatched()
        {

            var url = "https://api.trakt.tv/calendars/my/shows/2017-05-28/3";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var result = await _httpClientWrapper.DoRequest<object>(request);

            return result;
        }
    }
}
