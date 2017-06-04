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


namespace web_app.Gateways
{
    public class TheMovieDbGateway : ITheMovieDbGateway
    {
        private readonly IOptions<TheMovieDbApiConfiguration> _theMovieDb;
        private readonly IHttpClientWrap _httpClientWrap;

        public TheMovieDbGateway(IOptions<TheMovieDbApiConfiguration> theMovieDb, IHttpClientWrap httpClientWrap)
        {
            _theMovieDb = theMovieDb;
            _httpClientWrap = httpClientWrap;
        }

        public async Task<Response<MovieDbSerchResponseRootObject>> GetMovieInfo(string movie)
        {
            if (string.IsNullOrEmpty(movie))
                return new Response<MovieDbSerchResponseRootObject>
                {
                    Status = HttpStatusCode.BadRequest
                };

            var url = $"{_theMovieDb.Value.ApiBaseUrl}search/movie?api_key={_theMovieDb.Value.ApiKey}&language=en-US&query={movie}&page=1&include_adult=false";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await _httpClientWrap.DoRequest<MovieDbSerchResponseRootObject>(request);

            if (result.Status != HttpStatusCode.OK)
            {
                return new Response<MovieDbSerchResponseRootObject>();
            }
            var test = result.ResponseContent.results.FirstOrDefault();

            return result;
        }

    }
}
