using CapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ListingRepos repos;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            repos = new ListingRepos();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListingMapHome()
        {
            return View("ListingMap");
        }

        [HttpGet]
        public IActionResult ListingMap(double minPrice, double maxPrice, string input)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListingMap(double longi, double lat, int range)
        {
            return View();
        }

        public IActionResult ListingDetail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
