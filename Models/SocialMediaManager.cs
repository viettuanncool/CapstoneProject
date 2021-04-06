using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    //Context Class
    public class SocialMediaManager
    {
        private ISocialMedia socialMedia;


        public void createPost(string message, byte[] media)
        {   
            socialMedia.createPost(message, media);
        }

        public void setSocialMedia(ISocialMedia socialMedia)
        {
            this.socialMedia = socialMedia;
        }
    }
}
