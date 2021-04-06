using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class PostViewModel
    {
        public IFormFile File { get; set; }

        public string Message { get; set; }
        public byte[] MediaBinary { get; set; }

        [DisplayName("Twitter")]
        public bool TwitterActive { get; set; }

        [DisplayName("Facebook")]
        public bool FacebookActive { get; set; }

        [DisplayName("Instagram")]
        public bool InstagramActive { get; set; }
    }
}
