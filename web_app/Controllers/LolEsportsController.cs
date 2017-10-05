using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_app.Repository;
using web_app.Model;
using web_app.Http;
using web_app.Gateways;
using web_app.Extensions.ViewModelExtensions;

namespace web_app.Controllers
{
    public class LolEsportsController : Controller
    {
        private readonly ResponseHandler _handler;
        private readonly ILolEsportsGateway _gateway;

        public LolEsportsController(ILolEsportsGateway gateway)
        {
            _gateway = gateway;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpResponse = await _gateway.Get();

            var homepage = httpResponse._content as Team;

            var viewModel = homepage.ToLolEsportsTeamViewModel();

            return View(viewModel);
        }
    }
}