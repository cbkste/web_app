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
    public class LocalDbController : Controller
    {
        private readonly ILocalDbRepository _localDbRepository;

        public LocalDbController(ILocalDbRepository localDbRepository, IMovieDbMapper twitchMapper)
        {
            _localDbRepository = localDbRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = _localDbRepository.GetData("2");

            return View(response);
        }
    }
}