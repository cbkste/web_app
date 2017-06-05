using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Gateways;
using web_app.Gateways.Responses;
using web_app.Mappers;
using web_app.ViewModels;

namespace web_app.Services
{
    public class TheMovieDbService : ITheMovieDbService
    {
        private readonly ITheMovieDbGateway _theMovieDbgateway;
        private readonly IMovieDbMapper _movieDbMapper;

        public TheMovieDbService(ITheMovieDbGateway theMovieDbgateway, IMovieDbMapper movieMapper)
        {
            _theMovieDbgateway = theMovieDbgateway;
        }

        public async Task<MovieDbSearchViewModel> getSingleMovieInformation(int movieId)
        {
            var movieInfo = await _theMovieDbgateway.GetMovieInfo(movieId);
            var movieCast = await _theMovieDbgateway.GetMovieCastAndCrew(movieId);

            var movieData = new MovieDbSearchViewModel
            {
                cast = movieCast.ResponseContent,
                movieResults = movieInfo.ResponseContent
            };

            return movieData;
        }
    }
}
