using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Fiap.TellMeRain.Twitter.Service
{
    public class ExampleService
    {

        public void FirstSep()
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

            /*
             * After this we can handle tweets
             */
        }

        public void GetAutheticatedUser()
        {
            // Get the details of the Authenticated User
            var authenticatedUser = User.GetAuthenticatedUser();
        }

        public void GetMyTimeLine()
        {
            // Get my Home Timeline
            var tweets = Timeline.GetHomeTimeline();
        }
        public void PublishATweet()
        {
            var firstTweet = Tweet.PublishTweet("I love Tweetinvi!");
        }

        public void PublishWithCoordinates()
        {
            var france = new Coordinates(10000.546, 655654.98987);
            var tweet = Tweet.PublishTweet("Some love from France!", new PublishTweetOptionalParameters
            {
                Coordinates = france
            });
        }

    }
}
