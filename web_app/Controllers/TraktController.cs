using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_app.Gateways;
using web_app.ViewModels;
using web_app.Gateways.Responses;
using web_app.Mappers;

namespace web_app.Controllers
{
    public class TraktController : Controller
    {
        private readonly ITraktGateway _traktGateway;
        private readonly ITheMovieDbGateway _TheMovieDbGateway;
        private readonly IMovieDbMapper _movieDbMapper;

        public TraktController(ITraktGateway traktGateway, ITheMovieDbGateway movieDbGateway, IMovieDbMapper movieMapper)
        {
            _traktGateway = traktGateway;
            _TheMovieDbGateway = movieDbGateway;
            _movieDbMapper = movieMapper;
        }

        public async Task<IActionResult> Index()
        {
            //_traktGateway.getLastWatched();
            var response = await _TheMovieDbGateway.GetMovieInfo("The Dark Knight");


            var movieResponses =
                _movieDbMapper.Map<MovieDbSerchResponseRootObject, MovieDbSearchViewModel>(
                    response.ResponseContent);

            var result = movieResponses.movieResults.FirstOrDefault();

            return View(result);
        }
    }
}