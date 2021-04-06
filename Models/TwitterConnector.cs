using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Configuration;
using System.IO;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace CapstoneProject.Models
{
    //Strategy Class
    public class TwitterConnector : ISocialMedia
    {

        private string ConsumerKey = ConfigurationManager.AppSettings.Get("ConsumerKey");
        private string ConsumerSecret = ConfigurationManager.AppSettings.Get("ConsumerSecret");
        private string AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
        private string AccessTokenSecret = ConfigurationManager.AppSettings.Get("AccessTokenSecret");

        private TwitterClient userClient;

        public TwitterConnector()
        {
            initClient();
        }

        private void initClient()
        {
            userClient = new TwitterClient(ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);
        }

        public async Task createPost(string message, byte[] media)
        {
            if (media != null && media.Length > 0)
            {
                var uploadedImage = await userClient.Upload.UploadTweetImageAsync(media);
                var tweetWithImage = await userClient.Tweets.PublishTweetAsync(new PublishTweetParameters(message)
                {
                    Medias = { uploadedImage }
                });
            }
            else
            {
                var tweet = await userClient.Tweets.PublishTweetAsync(message);
            }
            
        }


    }
}
