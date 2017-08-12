using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_app.Repository;
using web_app.Model;
using web_app.Http;

namespace web_app.Controllers
{
    public class ContenfulHomepageController : Controller
    {
        private readonly ResponseHandler _handler;
        private readonly HomepageRepository _repository;

        public ContenfulHomepageController(HomepageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpResponse = await _repository.Get();

            var homepage = httpResponse._content as Homepage;

            return View(homepage);
        }
    }
}