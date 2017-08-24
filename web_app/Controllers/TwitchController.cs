using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_app.Repository;
using web_app.Model;
using web_app.Http;
using web_app.Gateways;
using web_app.Mappers;
using web_app.Gateways.Responses;
using web_app.ViewModels;

namespace web_app.Controllers
{
    public class TwitchController : Controller
    {
        private readonly ResponseHandler _handler;
        private readonly ITwitchGateway _twitchGateway;
        private readonly IMovieDbMapper _twitchMapper;

        public TwitchController(ITwitchGateway gateway, IMovieDbMapper twitchMapper)
        {
            _twitchGateway = gateway;
            _twitchMapper = twitchMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _twitchGateway.GetTrendingClipsForGame("test");

            var twitchMapResponse =
                    _twitchMapper.Map<TwitchTopClipsForGame, TwitchTopClipsForGameViewModel>(
                    response.ResponseContent);

            return View(twitchMapResponse);
        }
    }
}