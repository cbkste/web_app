using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_app.Gateways;
using web_app.ViewModels;

namespace web_app.Controllers
{
    public class FeedController : Controller
    {
        private readonly IPreDbGateway _preDbGateway;

        public FeedController(IPreDbGateway preDbGateway)
        {
            _preDbGateway = preDbGateway;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _preDbGateway.GetRssFeed();
                PreDbFeedViewModel model = new PreDbFeedViewModel();
                model.FeedItems = result;
                return View(model);

            } catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}
