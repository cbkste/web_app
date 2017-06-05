using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_app.Gateways;
using web_app.ViewModels;
using web_app.Gateways.Responses;
using web_app.Mappers;
using web_app.Services;

namespace web_app.Controllers
{
    public class TraktController : Controller
    {
        private readonly ITraktGateway _traktGateway;
        private readonly ITheMovieDbGateway _theMovieDbGateway;
        private readonly IMovieDbMapper _movieDbMapper;
        public readonly ITheMovieDbService _movieDbService;

        public TraktController(ITraktGateway traktGateway, ITheMovieDbService movieDbService, ITheMovieDbGateway theMovieDbGateway, IMovieDbMapper movieMapper)
        {
            _traktGateway = traktGateway;
            _movieDbService = movieDbService;
            _movieDbMapper = movieMapper;
            _theMovieDbGateway = theMovieDbGateway;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchMovieViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Details(SearchMovieViewModel search)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", search);
            }

            //var response = await _movieDbService.getSingleMovieInformation(search.MovieTitle);
            var response = await _theMovieDbGateway.SearchForMovie(search.MovieTitle);

            var movieResponses =
                _movieDbMapper.Map<MovieDbSerchResponseRootObject, SeletionMovieViewModel>(
                response.ResponseContent);

            movieResponses = new SeletionMovieViewModel
            {
                movieResults = new List<MovieDbSerchResponse>
                {
                    new MovieDbSerchResponse
                    {
                        id = 155
                    }
                }
            };

            if (movieResponses.movieResults.Count != 1)
                return View("Selection", movieResponses);

            var movieInfoResponse = await _movieDbService.getSingleMovieInformation(movieResponses.movieResults[0].id);

            return View(movieInfoResponse);
        }

        [HttpGet]
        public IActionResult Selection()
        {
            return View();
        }
    }
}