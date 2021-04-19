using CapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        ListingRepos repos;
        IQueryable<Listing> listings;

        private IHostingEnvironment _env;
        private string _dir;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            repos = new ListingRepos();
            listings = repos.Listings;

            _env = env;
            _dir = _env.ContentRootPath;
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

        
        public IActionResult SocialMediaHub()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SocialMediaHub(PostViewModel model)
        {
            SocialMediaManager s = new SocialMediaManager();

            string path = Path.Combine(_dir, "file.png");
            model.MediaBinary = System.IO.File.ReadAllBytes(path);

            if (model.TwitterActive)
            {
                s.setSocialMedia(new TwitterConnector());

                if (model.Message == null)
                {
                    ViewBag.msg = "The message cannot be blank";
                }
                else if (CharacterLimitCheck(model.Message.Length))
                {
                    s.createPost(model.Message, model.MediaBinary);
                    ViewBag.msg = "Posted!";
                }
                else
                {
                    ViewBag.msg = "The message is over the character limit";
                }
            }

            if (model.FacebookActive)
            {
                s.setSocialMedia(new FacebookConnector());
                s.createPost(model.Message, null);
            }

            if (model.InstagramActive)
            {
                s.setSocialMedia(new InstagramConnector());
                s.createPost(model.Message, null);
            }

            return View("SocialMediaHub");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool CharacterLimitCheck(int length)
        {
            if (length > 1 && length <= 280)
            {
                return true;
            }

            return false;
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
