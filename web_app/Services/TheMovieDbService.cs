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

        public async Task<MovieDbSearchViewModel> getSingleMovieInformation(string movie)
        {
            var response = await _theMovieDbgateway.SearchForMovie(movie);

            if (response.ResponseContent == null)
                return new MovieDbSearchViewModel();

            var id = response.ResponseContent.id;

            var movieInfo = await _theMovieDbgateway.GetMovieInfo(id);
            var moveiCast = await _theMovieDbgateway.GetMovieCastAndCrew(id);

            var movieData = new MovieDbSearchViewModel
            {
                movieResults = movieInfo.ResponseContent,
                cast = moveiCast.ResponseContent
            };

            return movieData;
        }
    }
}
