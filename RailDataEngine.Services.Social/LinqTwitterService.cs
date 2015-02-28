using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exceptionless;
using LinqToTwitter;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Services.TwitterService;

namespace RailDataEngine.Services.Social
{
    public class LinqTwitterService : ITwitterService
    {
        private readonly IScheduleGatewayContainer _scheduleGatewayContainer;

        public LinqTwitterService(IScheduleGatewayContainer scheduleGatewayContainer)
        {
            if (scheduleGatewayContainer == null)
                throw new ArgumentNullException("scheduleGatewayContainer");

            _scheduleGatewayContainer = scheduleGatewayContainer;
        }

        public void SendLateTweets(LateTrainTweetRequest request)
        {
            if (request.LateServiceList == null || !request.LateServiceList.Any())
                return;

            var tweets = request.LateServiceList.Select(BuildTweetContent).ToList();

            foreach (var tweet in tweets)
            {
                PostTweet(tweet);
            }
        }

        private async void PostTweet(string tweet)
        {
            var twitterAuthorizer = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"],
                    OAuthToken = ConfigurationManager.AppSettings["TwitterAccessToken"],
                    OAuthTokenSecret = ConfigurationManager.AppSettings["TwitterAccessTokenSecret"]
                }
            };
            
            using (var twitterContext = new TwitterContext(twitterAuthorizer))
            {
                try
                {
                    await twitterContext.TweetAsync(tweet);
                }
                catch (Exception exception)
                {
                    exception.ToExceptionless().AddObject(tweet).Submit();
                }
            }
        }

        private string BuildTweetContent(LateServiceTweetInfo lateServiceTweetInfo)
        {
            const string atocCode = "FGW";
            const string whiteSpace = " ";

            StringBuilder tweetBuilder = new StringBuilder();

            if (lateServiceTweetInfo.IsCorrection)
            {
                tweetBuilder.Append("CORRECTION:");
                tweetBuilder.Append(whiteSpace);    
            }

            tweetBuilder.Append(atocCode);
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append(lateServiceTweetInfo.PassengerTimestamp.ToString("t"));
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append("from");
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append(GetLocation(lateServiceTweetInfo.Stanox));
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append("has departed");
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append(lateServiceTweetInfo.Delay);
            tweetBuilder.Append(whiteSpace);
            tweetBuilder.Append("minutes late.");

            return tweetBuilder.ToString();
        }

        private string GetLocation(string stanox)
        {
            if (string.IsNullOrWhiteSpace(stanox))
                throw new ArgumentNullException("stanox");

            var tiploc = _scheduleGatewayContainer.TiplocGateway.Read(x => x.Stanox == stanox).First();

            return tiploc.TpsDescription;
        }
    }
}
