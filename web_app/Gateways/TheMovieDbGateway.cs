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
    public class TheMovieDbGateway : ITheMovieDbGateway
    {
        private readonly IOptions<TheMovieDbApiConfiguration> _theMovieDb;
        private readonly IOptions<UrlConfiguration> _urlConfig;
        private readonly IHttpClientWrap _httpClientWrap;

        public TheMovieDbGateway(IOptions<TheMovieDbApiConfiguration> theMovieDb, IOptions<UrlConfiguration> urlCOnfig, IHttpClientWrap httpClientWrap)
        {
            _theMovieDb = theMovieDb;
            _urlConfig = urlCOnfig;
            _httpClientWrap = httpClientWrap;
        }

        public async Task<Response<MovieDbSerchResponseRootObject>> SearchForMovie(string movie)
        {
            if (string.IsNullOrEmpty(movie))
                return new Response<MovieDbSerchResponseRootObject>
                {
                    Status = HttpStatusCode.BadRequest
                };

            var url = $"{_theMovieDb.Value.ApiBaseUrl}{_urlConfig.Value.MovieSearchUrl}?api_key={_theMovieDb.Value.ApiKey}&language=en-US&query={movie}&page=1&include_adult=false";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await _httpClientWrap.DoRequest<MovieDbSerchResponseRootObject>(request);

            if (result.Status != HttpStatusCode.OK)
            {
                return new Response<MovieDbSerchResponseRootObject>();
            }

            return result;
        }

        public async Task<Response<CastAndCrew>> GetMovieCastAndCrew(int movieId)
        {

            var url = $"{_theMovieDb.Value.ApiBaseUrl}movie/{movieId}/credits?api_key={_theMovieDb.Value.ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await _httpClientWrap.DoRequest<CastAndCrew>(request);

            if (result.Status != HttpStatusCode.OK)
            {
                return new Response<CastAndCrew>();
            }

            return result;
        }

        public async Task<Response<MovieViewModel>> GetMovieInfo(int movieId)
        {

            var url = $"{_theMovieDb.Value.ApiBaseUrl}movie/{movieId}?api_key={_theMovieDb.Value.ApiKey}&language=en-US";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await _httpClientWrap.DoRequest<MovieViewModel>(request);

            if (result.Status != HttpStatusCode.OK)
            {
                return new Response<MovieViewModel>();
            }

            return result;
        }
    }
}
