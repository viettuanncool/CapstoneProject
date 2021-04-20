using CapstoneProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class SocialController : Controller
    {

        private readonly ILogger<SocialController> _logger;

        private IHostingEnvironment _env;
        private string _dir;

        public SocialController(ILogger<SocialController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
            _dir = _env.ContentRootPath;
        }

        public IActionResult SocialMediaHub()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SocialMediaHub(PostViewModel model)
        {
            SocialMediaManager s = new SocialMediaManager();

            //string path = Path.Combine(_dir, "file.png");
            //model.MediaBinary = System.IO.File.ReadAllBytes(path);

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

        public bool CharacterLimitCheck(int length)
        {
            if (length > 1 && length <= 280)
            {
                return true;
            }

            return false;
        }
    }
}
