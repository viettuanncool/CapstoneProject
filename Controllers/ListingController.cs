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
    public class ListingController : Controller
    {
        private readonly ILogger<ListingController> _logger;

        ListingRepos repos;
        IQueryable<Listing> listings;

        public ListingController(ILogger<ListingController> logger)
        {
            _logger = logger;
            repos = new ListingRepos();
            listings = repos.Listings;
        }

        public IActionResult ListingMapHome()
        {
            return View("ListingMap");
        }

        [HttpGet]
        public IActionResult ListingMap(double minPrice, double maxPrice, string input)
        {
            var checks = StringInputCheck(input) && PriceInputCheck(minPrice, maxPrice);
            ViewBag.check = checks;
            return View(listings.Where(x => x.Price > minPrice && x.Price < maxPrice));
        }

        [HttpGet]
        public IActionResult ListingMap(double longi, double lat, int range)
        {
            return View();
        }

        public IActionResult ListingDetail(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool PriceInputCheck(double min, double max)
        {
            if (min < 0)
            {
                return false;
            }
            return min < max;
        }

        public bool StringInputCheck(string input)
        {
            List<string> invalidChars = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };

            // Check length
            if (input.Length > 25)
            {
                //return false;
                throw new Exception();
            }
            else
            {
                foreach (string s in invalidChars)
                {
                    if (input.Contains(s))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
